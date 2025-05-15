$(document).ready(() => {
    $('#formAdicionarUsuario').on('submit', e => {
        e.preventDefault()
        adicionarUsuario()
    })
})

function adicionarUsuario() {
    $('#loading').show()

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
        window.location = '/Administracao/'
    })
}

function criarObjetoFormulario() {
  
    return {
        nome: $("#nome").val(),
        email: $("#email").val(),
        nascimento: $("#nascimento").val(),
        cpf: $("#cpf").val(),
        telefone: $("#telefone").val()
    }
}
