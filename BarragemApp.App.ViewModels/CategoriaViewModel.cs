using System.Collections.Generic;

namespace BarragemApp.App.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public List<ListaProdutoViewModel> Produtos { get; set; }

        public CategoriaViewModel()
        {
            Produtos = new List<ListaProdutoViewModel>();
        }
    }
}