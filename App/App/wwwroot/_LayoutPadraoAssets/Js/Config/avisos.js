function gerarNotificacaoConfirmacao(onConfirmed) {
    $('#loading').hide()

    Swal.fire({
        title: 'Tem certeza?',
        text: "Tem certeza que deseja executar esta ação?",

        cancelButtonColor: 'red',
        cancelButtonText: 'Não',
        confirmButtonColor: 'var(--corPrincipal)',
        confirmButtonText: 'Sim',
        icon: 'warning',
        showCancelButton: true
    }).then(res => {
        if (res.isConfirmed) {
            onConfirmed()
        }
    })
}

function gerarNotificacaoErro(mensagem) {
    $('#loading').hide()

    new Notify({
        status: 'error',
        title: mensagem,

        autoclose: true,
        autotimeout: 5000,
        distance: 20,
        effect: 'slide',
        gap: 20,
        position: 'right bottom',
        showCloseButton: true,
        showIcon: true,
        speed: 300,
        type: 'outline'
    })
}

function gerarNotificacaoSucesso(mensagem) {
    $('#loading').hide()

    new Notify({
        status: 'success',
        title: mensagem,

        autoclose: true,
        autotimeout: 5000,
        distance: 20,
        effect: 'slide',
        gap: 20,
        position: 'right bottom',
        showCloseButton: true,
        showIcon: true,
        speed: 300,
        type: 'outline'
    })
}


$(document).on('ajaxError', (event, xhr, options) => {
    var tipo = 'erro';
    switch (xhr.status) {
        case 400:
        case 401:
        case 404:
            tipo = 'aviso';
            break
        case 504:
        case 422:
            tipo = 'erro';
            break
        default:
            tipo = 'erro';
            break

    }
    criarAlertaAjax(tipo, xhr.responseText, xhr.status)
})

$.fn.dataTable.ext.errMode = (settings, helpPage, message) => {
    criarAlertaAjax('erro', 'Ocorreu um erro ao realizar o carregamento da tabela: ' + message)
}

function criarAlertaAjax(tipo, mensagem, code) {
    console.log(mensagem)

    if (tipo == "aviso") {
        gerarNotificacaoErro(mensagem)

        setInterval(() => {
            if (code == 401) {
                window.location.reload();
            }
        }, 3000)
    } else {
        gerarNotificacaoErro('Algo deu errado...')
    }
}