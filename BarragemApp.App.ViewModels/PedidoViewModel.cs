using AppBarragem.Utils;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BarragemApp.App.ViewModels
{
    public class PedidoViewModel
    {
        public double ValorPedido { get; set; }
        public double ValorFrete { get; set; }
        public double ValorDesconto { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public bool CpfNaNota { get; set; }
        public TipoPedido Status { get; set; }
        public string DispositivoId { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string Observacao { get; set; }
        public int? CartaoId { get; set; }
        public int? CupomId { get; set; }
        public string CartaoPagarMeId { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteCelular { get; set; }

        public ObservableCollection<ProdutoPedido> Produtos { get; set; }

        public PedidoViewModel()
        {
            Produtos = new ObservableCollection<ProdutoPedido>();
        }
    }

    public class ProdutoPedido : BaseNotify
    {
        private int id;
        private string nome;
        private double preco;
        private int quantidade;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; OnPropertyChanged(); }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; OnPropertyChanged(); }
        }

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; OnPropertyChanged(); }
        }
    }

    public class BaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}