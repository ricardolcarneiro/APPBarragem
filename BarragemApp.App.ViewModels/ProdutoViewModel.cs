using System.Collections.Generic;
using System.Linq;

namespace BarragemApp.App.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public double Preco { get; set; }
        public double Avaliacao { get; set; }
        public int QntAvaliacao { get; set; }
        public List<AcompanhamentoViewModel> Acompanhamentos { get; set; }
        public List<OpcionalViewModel> Opcionais { get; set; }

        public ProdutoViewModel()
        {
            Acompanhamentos = new List<AcompanhamentoViewModel>();
            Opcionais = new List<OpcionalViewModel>();
        }

        public string TextAvaliacao => Avaliacao > 0 ? $"{Avaliacao.ToString("#,##0.0")} ({QntAvaliacao})" : "-";
        public bool TemOpcionais => (Opcionais != null && Opcionais.Any());
    }

    public class AcompanhamentoViewModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }

    public class OpcionalViewModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}