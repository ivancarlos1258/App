using App.Domain.DTOs.Usuario;
using App.Domain.HttpClient;
using App.Domain.TableModels;
using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace App.Pages.Administracao.Usuario
{
    [Authorize]
    public class NovoModel : PageModel
    {
        private readonly IApi _api;

        public NovoModel(IApi api)
        {
            _api = api;
        }

       

        public async Task OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost([FromBody] App.Domain.TableModels.Usuario novoUsuario)
        {
            var dto = new UsuarioPostDto
            {
                Cpf = novoUsuario.Cpf,
                Email = novoUsuario.Email,
                Nascimento = novoUsuario.Nascimento,
                Nome = novoUsuario.Nome,
                Telefone = novoUsuario.Telefone ,
                IsAtivo = true

            };

            await _api.CadastrarUsuario(dto);

            return StatusCode(200);
        }
    }
}
