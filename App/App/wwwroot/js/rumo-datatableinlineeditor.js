//#####################################################
//##                                                 ##
//## 
//##                                                 ##
//#####################################################

// Adicionar comportamento ao clicar no botão "Editar"
$('body').on('click', '.edit-button', function() {
    var row = $(this).closest('tr');
    var fields = row.find('td:not(:last-child)');
    var oldValues = [];

    // Armazenar os valores antigos de cada campo
    fields.each(function() {
        var oldValue = $(this).text();
        oldValues.push(oldValue);
    });
    
    var configs = $.parseJSON($(this).attr('data-json-config'));

    fields.each(function(index) {
        for (var cIndex = 0; cIndex < configs.length; cIndex++)
        {
            var cRow = configs[cIndex];
            if (cRow.OptionsValues)
                continue

            if (cRow.Position == index)
            {
                var complementoInput = "";
                if (cRow.MaxLength != null)
                {
                    complementoInput += 'maxlength="' + cRow.MaxLength + '"';
                }
                if (cRow.MaxNumber != null)
                {
                    complementoInput += 'max="' + cRow.MaxNumber + '"';
                }

                if (!cRow.TemDoisInputs)
                    $(this).html('<input type="text" class="' + cRow.Class + '" value="' + $(this).text() + '" ' + complementoInput + '>');
                else {
                    const valorInput1 = $(this).text().slice(0, 3)
                    var valorInput2 = $(this).text().slice(-3)
                    if (valorInput2 == '00%')
                        valorInput2 = '100%'

                    $(this).html(`<div class="align-items-center d-flex">
                        <input disabled id="inputClassificacao1" type="text" class="${cRow.Class}" value="${valorInput1}" ${complementoInput} style="width: 45%">
                        <p class="mx-1 my-0"> - </p>
                        <input id="inputClassificacao2" type="text" class="${cRow.Class}" value="${valorInput2}" ${complementoInput} style="width: 45%">
                    `);
                }
            }
        }
    });

    $(this).hide();
    row.find('button').hide();
    row.find('.cancel-button').show();
    row.find('.save-button').show();
    row.data('oldValues', oldValues);
    row.closest('td').find('.edit-button').hide();
    aplicarMascarasValores();
});

// Adicionar comportamento ao clicar no botão "Cancelar"
$('body').on('click', '.cancel-button', function() {
    var row = $(this).closest('tr');
    var fields = row.find('td:not(:last-child)');
    var oldValues = row.data('oldValues');

    // Restaurar os valores antigos de cada campo
    fields.each(function (index) {
        if ($(this)[0].firstChild.type != 'checkbox')
            $(this).text(oldValues[index]);
    });

    $(this).hide();
    row.find('button').show();
    row.find('.edit-button').show();
    row.find('.edit-button-select').show();
    row.find('.cancel-button').hide();
    row.find('.save-button').hide();
    row.closest('td').find('.edit-button').show();
});

// Adicionar comportamento ao clicar no botão "Salvar"
$('body').on('click', '.save-button', function() {
    var row = $(this).closest('tr');
    var fields = row.find('td:not(:last-child)');
    var newValues = [];
    var selectsTexts = []

    // Obter os novos valores de cada campo
    fields.each(function (index) {
        var isSelect = false
        var inputs
        inputs = $(this).find('input')
        if (inputs.length == 0) {
            inputs = $(this).find('select')
            isSelect = true
        }
        
        for (let i = 0; i < inputs.length; i++)
            newValues.push($(inputs[i]).val())
            
        if (inputs.length <= 0)
            newValues.push($(this).text())

        if (isSelect)
            selectsTexts.push({
                index: index,
                text: $(this).find(':selected').text()
            })
    });
    
    var customAction = $(this).attr('data-customaction');
    
    $('#loading').show();
    $.ajax({
        url: $(this).attr('data-url-save'),
        method: "PUT",
        async: true,
        contentType: "application/json",
        data: JSON.stringify(newValues)
    }).done(function (r) {
        $('#loading').hide();

        // Atualizar os campos com os novos valores
        fields.each(function (index) {
            if ($(this)[0].firstChild.type != 'checkbox') {
                var selectText = selectsTexts.find(t => t.index == index)
                if (selectText) {
                    $(this).text(selectText.text)
                } else {
                    $(this).text(newValues[index]);
                }
            }
        });

        $(this).hide();
        row.find('button').show();
        row.find('.edit-button').show();
        row.find('.edit-button-select').show();
        row.find('.cancel-button').hide();
        row.find('.save-button').hide();
        row.closest('td').find('.edit-button').show();

        if (customAction != "")
            eval(customAction);
    });
});

//
// Para gerar um <select>
//
$('body').on('click', '.edit-button-select', function () {
    var row = $(this).closest('tr');
    var fields = row.find('td:not(:last-child)');
    var oldValues = [];

    // Armazenar os valores antigos de cada campo
    fields.each(function () {
        var oldValue = $(this).text();
        oldValues.push(oldValue);
    });

    var configs = $.parseJSON($(this).attr('data-json-config'));
    
    fields.each(function (index) {
        for (var cIndex = 0; cIndex < configs.length; cIndex++) {
            var cRow = configs[cIndex];
            if (!cRow.OptionsValues)
                continue

            if (cRow.Position == index) {
                var options = ''
                cRow.OptionsValues.forEach((optValue, optIndex) => {
                    var optText = cRow.OptionsTexts[optIndex]

                    options += `<option value="${optValue}" ${optText == oldValues[index] ? "selected" : ""}>${optText}</option>`
                })
                
                $(this).html(`<select class="selectEdicaoDatatables ${cRow.Class}">
                    ${options}
                </select>`);
            }
        }
    });

    $(this).hide()
    row.closest('td').find('.edit-button-selcet').hide()
    aplicarMascarasValores()
    $('.selectEdicaoDatatables').addClass('form-select')
});

