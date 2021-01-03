using System.Collections.Generic;

namespace BarragemApp.App.ViewModels
{
    public class PracaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public List<ListaCategoriaViewModel> Categorias { get; set; }

        public PracaViewModel()
        {
            Categorias = new List<ListaCategoriaViewModel>();
        }
    }
}