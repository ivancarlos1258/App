
namespace TargetApp
{
    public class HeaderTokenHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenGlobal.Token);

           
            var retorno = await base.SendAsync(request, cancellationToken);

            return retorno;
        }
    }
}
