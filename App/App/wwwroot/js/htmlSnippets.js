const htmlSnippets = {
    botaoEditar(onClick) {
        return `<button class="btn btn-sm btn-default" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Editar" onclick="${onClick}" type="button"><i class="bi bi-pen"></i></button>`;
    },

    botaoExcluir(onClick) {
        return `<button class="btn btn-sm btn-default" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Remover" onclick="${onClick}" type="button"><i class="bi bi-trash"></i></button>`;
    }
}