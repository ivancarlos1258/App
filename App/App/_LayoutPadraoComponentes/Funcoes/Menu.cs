using LayoutPadrao.Models;
using System.Text;
using System.Text.Json;

namespace LayoutPadrao.Funcoes
{
    public static class Menu
    {
        public static ItemMenu[] Construir(UsuarioLogado usuarioLogado)
        {
            try
            {
                var menu = LerJson();
                menu = RemoverMenusVazios(menu);
                menu = ValidarPermissoes(menu, usuarioLogado);
                return menu;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Não foi possível construir o menu: " + ex.Message);
            }
        }

        private static ItemMenu[] LerJson()
        {
            using (var swr = new StreamReader($"Menu.json", Encoding.UTF8, true))
            {
                var conteudoJson = swr.ReadToEnd();

                return JsonSerializer.Deserialize<ItemMenu[]>(conteudoJson);
            }
        }

        private static ItemMenu[] RemoverMenusVazios(ItemMenu[] itensMenu)
        {
            List<ItemMenu> itensRemover = new List<ItemMenu>();

            foreach (var item in itensMenu)
            {
                if (string.IsNullOrWhiteSpace(item.RotaUrl) && (item.Itens is null || item.Itens.Length == 0))
                    itensRemover.Add(item);

                if (item.Itens is not null && item.Itens.Length > 0)
                {
                    List<ItemMenu> miniItensRemover = new List<ItemMenu>();

                    foreach (var miniItem in item.Itens)
                    {
                        if (string.IsNullOrWhiteSpace(miniItem.RotaUrl) && (miniItem.Itens is null || miniItem.Itens.Length == 0))
                            miniItensRemover.Add(miniItem);
                    }

                    item.Itens = item.Itens.Where(i => !miniItensRemover.Contains(i)).ToArray();
                }
            }

            itensMenu = itensMenu.Where(i => !itensRemover.Contains(i)).ToArray();

            return itensMenu;
        }

        private static ItemMenu[] ValidarPermissoes(ItemMenu[] itensMenu, UsuarioLogado usuarioLogado)
        {
            List<ItemMenu> itensRemover = new List<ItemMenu>();

            foreach (var item in itensMenu)
            {
                if (!string.IsNullOrWhiteSpace(item.Permissao) && !usuarioLogado.IsPermissao(item.Permissao))
                    itensRemover.Add(item);

                if (item.Itens is not null && item.Itens.Length > 0)
                {
                    List<ItemMenu> miniItensRemover = new List<ItemMenu>();

                    foreach (var miniItem in item.Itens)
                    {
                        if (!string.IsNullOrWhiteSpace(miniItem.Permissao) && !usuarioLogado.IsPermissao(miniItem.Permissao))
                            miniItensRemover.Add(miniItem);
                    }

                    item.Itens = item.Itens.Where(i => !miniItensRemover.Contains(i)).ToArray();
                }
            }

            itensMenu = itensMenu.Where(i => !itensRemover.Contains(i)).ToArray();

            return itensMenu;
        }
    }
}
