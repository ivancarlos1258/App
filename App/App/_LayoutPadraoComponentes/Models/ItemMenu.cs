namespace LayoutPadrao.Models
{
    public class ItemMenu
    {
        /// <summary>
        /// Permissao necessária para liberar a visibilidade do menu, deixar null ou vazia caso não precise
        /// </summary>
        public string? Permissao { get; set; }
        public string Texto { get; set; }
        public string? RotaUrl { get; set; }

        /// <summary>
        /// Declarar aqui a tag conforme bootstrap icons
        /// </summary>
        public string Icone { get; set; }

        /// <summary>
        /// Caso tenha submenus, submenus não suportam icones
        /// </summary>
        public ItemMenu[] Itens { get; set; }
    }
}
