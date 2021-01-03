using System;
using System.Collections.Generic;

namespace BarragemApp.App.ViewModels
{
    public class ListarPedidoViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public int? Avaliacao { get; set; }
        public string NumeroPedido { get; set; }
        public List<ProdutoPedidoViewModel> Produtos { get; set; }
        public bool PodeCancelar { get; set; }

        public string Status { get; set; }
        public double ValorFrete { get; set; }
        public double ValorPedido { get; set; }
        public string TipoPagamento { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string Observacao { get; set; }

        public ListarPedidoViewModel()
        {
            Produtos = new List<ProdutoPedidoViewModel>();
        }
    }

    public class ProdutoPedidoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public string Preco { get; set; }
        public int? Avaliacao { get; set; }
    }
}