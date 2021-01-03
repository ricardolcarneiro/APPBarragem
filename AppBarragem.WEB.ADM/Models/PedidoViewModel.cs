using ZeNerd.DAL.Context;
using AppBarragem.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{

    public class PedidoViewModel
    {
        [Required]
        public double ValorPedido { get; set; }
        public double ValorFrete { get; set; }
        public double ValorDesconto { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public bool CpfNaNota { get; set; }
        public TipoPedido Status { get; set; }
        public string DispositivoId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(8)]
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Complemento { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string Observacao { get; set; }
        public int? CartaoId { get; set; }
        public Cartao Cartao { get; set; }
        public int? CupomId { get; set; }
        public string CartaoPagarMeId { get; set; }

        #region Clientes
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteCelular { get; set; }
        #endregion

        public ObservableCollection<ProdutoPedidos> Produtos { get; set; }

        public PedidoViewModel()
        {
            Produtos = new ObservableCollection<ProdutoPedidos>();
            Cartao = new Cartao();
        }
    }

    public class ProdutoPedidos : BaseNotify
    {
        private int id;
        private string nome;
        private double preco;
        private int quantidade;

        private int? avaliacao;
        private bool ativo;
        private System.DateTime dataCriacao;
        private byte[] dataAtualizacao;
        private int produtoId;
        private int pedidoId;


        public int? Avaliacao { get => avaliacao; set => avaliacao = value; }
        public bool Ativo { get => ativo; set => ativo = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public byte[] DataAtualizacao { get => dataAtualizacao; set => dataAtualizacao = value; }
        public int ProdutoId { get => produtoId; set => produtoId = value; }
        public int PedidoId { get => pedidoId; set => pedidoId = value; }



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