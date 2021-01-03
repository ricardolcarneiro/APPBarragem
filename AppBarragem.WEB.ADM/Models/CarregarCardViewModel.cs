using ZeNerd.DAL.Context;
using System.Collections.Generic;

namespace AppBarragem.WEB.ADM.Models
{
    public class CarregarCardViewModel
    {
        //public List<Pedido> lstPedidosSolicitado { get; set; }
        //public List<Pedido> lstPedidosEmAndamento { get; set; }
        //public List<Pedido> lstPedidoPronto { get; set; }
        //public List<Pedido> lstPedidosAtrasado { get; set; }
        //public List<Pedido> lstPedidosACaminho { get; set; }
        //public List<Pedido> lstPedidosEntregue { get; set; }
        //public List<Pedido> lstPedidosCancelado { get; set; }

        public CarregarCardViewModel()
        {
            lstPedidosSolicitado = new List<Pedido>();
            lstPedidosEmAndamento = new List<Pedido>();
            lstPedidoPronto = new List<Pedido>();
            lstPedidosAtrasado = new List<Pedido>();
            lstPedidosACaminho = new List<Pedido>();
            lstPedidosEntregue = new List<Pedido>();
            lstPedidosCancelado = new List<Pedido>();
        }
    }
}