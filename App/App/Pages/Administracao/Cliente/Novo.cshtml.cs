using App.Domain.DTOs.Cliente;
using App.Domain.HttpClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Cliente
{
    [Authorize]
    public class NovoModel : PageModel
    {
        private readonly IApi _api;

        public NovoModel(IApi api)
        {
            _api = api;
        }

        public async Task<IActionResult> OnPost([FromBody] Domain.TableModels.Cliente novoCliente)
        {
            var dto = new ClientePostDto
            {
                Documento = novoCliente.Documento
                //todos os outros campos

            };

            await _api.CadastrarCliente(dto);

            return StatusCode(200);
        }
    }
}
