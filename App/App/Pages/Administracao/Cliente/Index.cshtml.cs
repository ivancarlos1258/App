using App.Domain.HttpClient;
using App.Domain.Models;
using App.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Cliente
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IApi _api;

        public IndexModel(IApi api)
        {
            _api = api;
        }

        public async Task<IActionResult> OnGetTabela(bool trazerInativos, DataTableAjax datatableModel)
        {
            var query = Conversoes.DatatableModelParaGridifyQuery(datatableModel);
            query.Filter = $"IsAtivo={!trazerInativos}";

            var clientes = await _api.ListarClientesPaginado(query);

            var data = new
            {
                draw = Convert.ToInt32(datatableModel.draw),
                recordsTotal = clientes.Count,
                recordsFiltered = clientes.Count,
                data = clientes.Data.Select(x => new string[] {
                    x.RazaoSocial,
                    x.NomeFantasia,
                    Conversoes.FormatarCPFCNPJ(x.Documento),
                    HtmlSnippets.CriarBotaoCanetaDataTables($"window.location = '/Cliente/' + {x.CodigoCliente}")
                }).ToList()
            };

            return StatusCode(200, data);
        }
    }
}
