namespace BarragemApp.App.ViewModels
{
    public class ListaProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public double Preco { get; set; }
        public double Avaliacao { get; set; }
        public int QntAvaliacao { get; set; }
        public int Ordem { get; set; }

        public string TextAvaliacao => Avaliacao > 0 ? $"{Avaliacao.ToString("#,##0.0")} ({QntAvaliacao})" : "-";
    }
}