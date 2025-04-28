using App.Domain.DTOs.Auth;
using App.Domain.DTOs.Usuario;
using App.Domain.Enums;
using Gridify;
using Refit;
using System.Security.Claims;

namespace App.Domain.HttpClient
{
    public interface IApi
    {
        #region Auth
        [Post("/Auth/GerarToken")]
        Task<TokenGetDto> GetToken([Body] Guid identificador);

        [Post("/Auth/Autenticar")]
        Task<string> Autenticar([Body] LoginDto loginDto);

        [Post("/Auth/SolicitarRecuperacaoSenha")]
        Task SolicitarRecuperacaoSenha([Body] RecuperacaoSenhaDto recuperacaoSenhaDto);

        [Post("/Auth/RedefinirSenha")]
        Task RedefinirSenha([Body] LoginDto loginDto);

        [Post("/Auth/RedefinirSenhaComToken")]
        Task RedefinirSenhaComToken([Body] RecuperacaoSenhaDto recuperacaoSenhaDto);
        #endregion

        #region Usuario
        [Get("/Usuario/{identificador}")]
        Task<UsuarioGetDto> ObterUsuarioPorIdentificador(Guid identificador);

        [Get("/Usuario")]
        Task<Paging<UsuarioGetDto>> ListarUsuariosPaginado([Query] GridifyQuery gridifyQuery);

        [Post("/Usuario")]
        Task CadastrarUsuario([Body] UsuarioPostDto usuarioPostDto);

        [Put("/Usuario")]
        Task AtualizarUsuario([Body] UsuarioPutDto usuarioPutDto);

        [Put("/Usuario/AtivarDesativar/{identificador}")]
        Task AtivarDesativarUsuario(Guid identificador);

        [Put("/Usuario/SolicitarAlteracaoSenha/{identificador}")]
        Task SolicitarRedefinicaoSenhaUsuario(Guid identificador);

        [Put("/Usuario/AtualizarSenha")]
        Task AtualizarSenhaUsuario([Query] Guid identificador, string senha);
        #endregion
    }
}
