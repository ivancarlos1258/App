namespace LayoutPadrao.Models
{
    public class UsuarioLogado
    {
        public Guid? IdentificadorUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        /// <summary>
        /// Lista de permissões que o usuário possui
        /// </summary>
        public string[] Permissoes { get; set; }

        public bool IsPermissao(string permissao) => Permissoes.Any(x => x == permissao);
    }
}
