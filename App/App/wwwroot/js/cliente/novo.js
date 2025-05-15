$(document).ready(function () {
    $('#formIncluirCliente').on('submit', e => {
        e.preventDefault()
        incluirCliente()
    })
})

function incluirCliente() {
    $('#loading').show()
    debugger;
    var dados = criarObjetoFormulario()

    $.ajax({
        url: window.location.pathname,
        method: "POST",
        async: true,
        contentType: "application/json",
        headers: { 'RequestVerificationToken': tokenAntiForja },
        data: JSON.stringify(dados)
    }).done(() => {
        $('#loading').hide()
        window.location = '/Cliente'
    })
}

function criarObjetoFormulario() {
    return {
        nome: $('#nomefantasia').val(),
        documento: $('#documento').val().replaceAll(".", "").replaceAll("-", "").replaceAll("/", "")
    }
}
