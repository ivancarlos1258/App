using App.Domain.HttpClient;
using App.Domain.Models;
using App.Utility;
using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace App.Pages.Administracao.Usuario
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

            var usuarios = await _api.ListarUsuariosPaginado(query);

            var data = new
            {
                draw = Convert.ToInt32(datatableModel.draw),
                recordsTotal = usuarios.Count,
                recordsFiltered = usuarios.Count,
                data = usuarios.Data.Select(x => new string[] {
                    x.Nome,
                    x.Email,
                    HtmlSnippets.CriarSwitchDataTables(x.IsAtivo, $"ativarDesativar('{x.Id}')",x.Id),
                    HtmlSnippets.CriarBotaoCanetaDataTables($"window.location = '/Administracao/Usuario/' + {x.Id}")
                }).ToList()
            };

            return StatusCode(200, data);
        }

        public async Task<IActionResult> OnPutTabela(Guid idUsuario)
        {
            await _api.AtivarDesativarUsuario(idUsuario);
            return StatusCode(200);
        }
    }
}
