$(document).ready(() => {
    $("#formEditarUsuario").on('submit', e => {
        e.preventDefault()
        atualizarUsuario()
    })

    $('input').on('change', () => {
        $('#botaoSalvar').prop('disabled', false)
    })
})

function ativarDesativar(elemento, idUsuario) {
    if ($(elemento).is(":checked"))
        $(elemento).prop('checked', false)
    else
        $(elemento).prop('checked', true)

    gerarNotificacaoConfirmacao(() => {
        $.ajax({
            url: `?handler=ativarDesativar&idUsuario=${idUsuario}`,
            method: "PUT",
            async: true,
            headers: { 'RequestVerificationToken': tokenAntiForja },
        }).done(() => {
            window.location.reload()
        })
    })
}

function atualizarUsuario() {
    $('#loading').show()

    var dados = criarObjetoFormulario()
    dados.id = idUsuario
    dados.isAtivo = isAtivo

    $.ajax({
        url: window.location.pathname,
        method: "PUT",
        async: true,
        contentType: "application/json",
        headers: { 'RequestVerificationToken': tokenAntiForja },
        data: JSON.stringify(dados)
    }).done(function () {
        $('#loading').hide()

        window.location.reload()
    })
}

function redefinirSenha() {
    gerarNotificacaoConfirmacao(() => {
        $('#loading').show()

        $.ajax({
            url: "?handler=solicitarRedefinicaoSenha&idUsuario=" + idUsuario,
            method: "PUT",
            headers: { 'RequestVerificationToken': tokenAntiForja },
            async: true
        }).done(() => {
            $('#loading').hide()
            gerarNotificacaoSucesso('Redefinição de senha solicitada com sucesso.')
        })
    })
}