using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using App.Domain.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using App.Domain.HttpClient;
using System.Threading.Tasks;
using App.Domain.DTOs.Auth;

namespace App.Pages.Auth
{
    [AllowAnonymous]
    public class RecoverModel : PageModel
    {
        private readonly IApi _api;

        public RecoverModel(IApi api)
        {
            _api = api;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/");

            return Page();
        }

        public async Task<IActionResult> OnPostSolicitarRecuperacaoSenha([FromBody] RecuperacaoSenhaDto model)
        {
            try
            {
                await _api.SolicitarRecuperacaoSenha(model);
                return StatusCode(200);
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao solicitar a recuperação de senha.");
            }
        }

        public async Task<IActionResult> OnPutRedefinirSenhaComToken([FromBody] RecuperacaoSenhaDto model)
        {
            try
            {
                await _api.RedefinirSenhaComToken(model);
                return StatusCode(200);
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao redefinir a senha.");
            }
        }
    }
}