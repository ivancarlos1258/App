var tabelaUsuarios
var urlTabela = '?handler=tabela'

$(document).ready(function () {
    tabelaUsuarios = $('#tabelaUsuarios').DataTable({
        ajax: urlTabela + '&trazerInativos=false',
        columnDefs: [
            { targets: [2], searchable: false, width: 20 }
        ]
    })
})

function ativarDesativar(idUsuario) {


    gerarNotificacaoConfirmacao(() => {
        $.ajax({
            url: urlTabela + '&idUsuario=' + idUsuario,
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
    tabelaUsuarios.ajax.url(url).load()
}