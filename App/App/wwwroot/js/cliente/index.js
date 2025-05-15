var tabelaClientes
var urlTabela = '?handler=tabela'

$(document).ready(() => {
    tabelaClientes = $('#tabelaClientes').DataTable({
        ajax: urlTabela + '&trazerInativos=false',
        columnDefs: [
            { targets: [3, 4], searchable: false, width: 20 }
        ]
    })
})

function ativarDesativar(elemento, idCliente) {
    if ($(elemento).is(":checked"))
        $(elemento).prop('checked', false)
    else
        $(elemento).prop('checked', true)

    gerarNotificacaoConfirmacao(() => {
        $.ajax({
            url: `?handler=ativarDesativar&idCliente=${idCliente}`,
            method: "PUT",
            async: true,
            headers: { 'RequestVerificationToken': tokenAntiForja },
        }).done(() => {
            window.location.reload()
        })
    })
}

function reloadTabela() {
    var url = `${urlTabela}&trazerInativos=${$('#inputTrazerInativos').is(':checked')}`
    tabelaClientes.ajax.url(url).load()
}