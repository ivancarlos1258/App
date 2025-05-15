using App.Domain.DTOs.Auth;
using App.Domain.Exceptions;
using App.Domain.HttpClient;
using App.Domain.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using TargetApp;

namespace App.Pages.Auth
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IApi _api;


        public LoginModel(IApi api)
        {
            _api = api;

        }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/");

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).GetAwaiter();
            TokenGlobal.Token=string.Empty;

            return Redirect("/Auth/Login");
        }

        public async Task<IActionResult> OnPostAutenticar([FromBody] LoginDto model)
        {
            try
            {
                var claimsstring = await _api.Autenticar(model);
                var claims = JsonConvert.DeserializeObject<List<MyClaim>>(claimsstring);
                var clienteId = Guid.Parse(claims.FirstOrDefault(x => x.Type == "IdentificadorUsuario").Value);
                var token = await _api.GetToken(clienteId);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties() { IsPersistent = model.Lembrar, AllowRefresh = true };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).GetAwaiter();
                TokenGlobal.Token = token.IdentificadorToken;

                return StatusCode(200);
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(401, "Usuário ou senha incorretos.");
            }
        }
    }
}