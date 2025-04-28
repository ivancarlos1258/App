using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace App.Pages.Error
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public string Mensagem { get; set; } = "";
        public string StackTrace { get; set; } = "";

        public IActionResult OnGetCode(int code)
        {
            var isAjax = HttpContext.Request.Headers.XRequestedWith == "XMLHttpRequest";

            if (isAjax)
            {
                
                return code switch
                {
                    400 => StatusCode(400, "A requisição enviada é inválida."),
                    401 => StatusCode(401, "Sua sessão expirou."),
                    403 => StatusCode(403, "Você não tem permissão para executar essa ação."),
                    404 => StatusCode(404, "Recurso não encontrado."),
                    405 => StatusCode(422, "Metodo ou verbo não compatível com o declarado na controladora."),
                    500 => StatusCode(422, "Ocorreu um erro ao processar a requisição."),
                    504 => StatusCode(504, "O servidor não recebeu uma resposta oportuna da controladora."),
                    _ => StatusCode(code),
                };
            }

            return code switch
            {
                503 => Redirect("/Error/SemConexao"),
                403 => Redirect("/Error/NaoAutorizado"),
                404 => Redirect("/Error/PaginaNaoEncontrada"),
                _ => Redirect("/Error"),
            };
        }

        public IActionResult OnGet()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var isAjax = HttpContext.Request.Headers.XRequestedWith == "XMLHttpRequest";

            if (context is not null && context.Error is not null)
            {
                var ex = context.Error;

                //if(ex is ApiException errApi)
                //{
                //    if (errApi.Content is not null)
                //    {
                //        var erro = JsonConvert.DeserializeObject<ErrorResponse>(errApi.Content);
                //        var mensagemDeErro = erro.Messages.Last();

                //        return StatusCode((int)errApi.StatusCode, mensagemDeErro.Message);
                //    }
                //}
                
                if(isAjax)
                    return StatusCode(400, ex.Message);

                Mensagem = ex.Message;
                StackTrace = ex.StackTrace;
            }
            
            return Page();
        }
        public IActionResult OnPost()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var isAjax = HttpContext.Request.Headers.XRequestedWith == "XMLHttpRequest";

            if (context is not null && context.Error is not null)
            {
                var ex = context.Error;

                //if(ex is ApiException errApi)
                //{
                //    if (errApi.Content is not null)
                //    {
                //        var erro = JsonConvert.DeserializeObject<ErrorResponse>(errApi.Content);
                //        var mensagemDeErro = erro.Messages.Last();

                //        return StatusCode((int)errApi.StatusCode, mensagemDeErro.Message);
                //    }
                //}
              
                if(isAjax)
                    return StatusCode(400, ex.Message);

                Mensagem = ex.Message;
            }

            return Page();
        }
        public IActionResult OnPut()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var isAjax = HttpContext.Request.Headers.XRequestedWith == "XMLHttpRequest";

            if (context is not null && context.Error is not null)
            {
                var ex = context.Error;

                //if(ex is ApiException errApi)
                //{
                //    if (errApi.Content is not null)
                //    {
                //        var erro = JsonConvert.DeserializeObject<ErrorResponse>(errApi.Content);
                //        var mensagemDeErro = erro.Messages.Last();

                //        return StatusCode((int)errApi.StatusCode, mensagemDeErro.Message);
                //    }
                //}

                if(isAjax)
                    return StatusCode(400, ex.Message);

                Mensagem = ex.Message;
            }

            return Page();
        }
        public IActionResult OnDelete()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var isAjax = HttpContext.Request.Headers.XRequestedWith == "XMLHttpRequest";

            if (context is not null && context.Error is not null)
            {
                var ex = context.Error;

                //if(ex is ApiException errApi)
                //{
                //    if (errApi.Content is not null)
                //    {
                //        var erro = JsonConvert.DeserializeObject<ErrorResponse>(errApi.Content);
                //        var mensagemDeErro = erro.Messages.Last();

                //        return StatusCode((int)errApi.StatusCode, mensagemDeErro.Message);
                //    }
                //}
                
                if(isAjax)
                    return StatusCode(400, ex.Message);

                Mensagem = ex.Message;
            }

            return Page();
        }
    }
}
