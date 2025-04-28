$.extend(true, $.fn.dataTable.defaults, {
   	columnDefs: [
		{
			targets: '_all', orderable: false
		}
   	],
    language: {
        url: "/_LayoutPadraoAssets/Lang/Datatable/pt-br.json"
    },
    order: false,
    responsive: true,

    initComplete: function () {
      var idTabela = $(this).attr('id')
      reformatarTabela(idTabela)
      
      $('.dt-column-order').remove()
      
      configurarTooltips()
    },

    processing: true,
    serverSide: true
})

function reformatarTabela(idTabela) {
    var divPai = $(`#${idTabela}_wrapper`)

    var seletorTamanho = divPai.find('.dt-length').closest('.dt-layout-cell')
    var rowSeletorTamanho = seletorTamanho.closest('.dt-layout-row')

    var rowInfosPaginacao = divPai.find('.dt-paging').closest('.dt-layout-row')

    seletorTamanho.appendTo(divPai)
    rowInfosPaginacao.appendTo(divPai)

    if (rowSeletorTamanho.find('.dt-search').length == 0) {
        rowSeletorTamanho.remove()
    }
}