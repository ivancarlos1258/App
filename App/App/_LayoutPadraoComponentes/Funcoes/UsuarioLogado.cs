using LayoutPadrao.Models;
using System.Security.Claims;

namespace LayoutPadrao.Funcoes
{
    public static class DadosUsuarioLogado
    {
        public static UsuarioLogado ObterUsuarioLogado(IEnumerable<Claim> claims)
        {
            try
            {
                return new UsuarioLogado()
                {
                    IdentificadorUsuario = claims.Any(x => x.Type == "IdentificadorUsuario") ? Guid.Parse(claims.First(x => x.Type == "IdentificadorUsuario").Value) : null,
                    Nome = claims.Any(x => x.Type == "Nome") ? claims.First(x => x.Type == "Nome").Value : null,
                    Email = claims.Any(x => x.Type == "Email") ? claims.First(x => x.Type == "Email").Value : null,
                    Permissoes = claims.Any(x => x.Type == "Permissoes") ? claims.First(x => x.Type == "Permissoes").Value.Split(';') : []
                };
            }
            catch (Exception)
            {
                throw new InvalidCastException("Não foi possível recuperar os valores do usuário logado.");
            }
        }

        public static string? RecuperaClaim(IEnumerable<Claim> claims, string claim)
        {
            return claims.Any(x => x.Type == claim) ? claims.First(x => x.Type == claim).Value : null;
        }
    }
}