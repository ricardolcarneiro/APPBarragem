using AppBarragem.Utils;
using System.Collections.Generic;

namespace AppBarragem.WEB.ADM.Models
{
    public class MasterControlePedidoViewModel
    {
        public List<ControlePedidoViewModel> Pedidos { get; set; }
        public MotoBoyViewModel MotoBoyModal { get; set; }
    }

    public class ControlePedidoViewModel
    {
        public int Id { get; set; }
        public string DataPedido { get; set; }
        public string NumeroPedido { get; set; }
        public string NomeCliente { get; set; }
        public string Bairro { get; set; }
        public List<PratoViewModel> Pratos { get; set; }
        public string Preco { get; set; }
        public string Frete { get; set; }
        public string Desconto { get; set; }
        public string ValorTotal { get; set; }
        public string Observacao { get; set; }
        public TipoPedido Status { get; set; }

        public ControlePedidoViewModel()
        {
            Pratos = new List<PratoViewModel>();
        }
    }

    public class PratoViewModel
    {
        public int Qnt { get; set; }
        public string Nome { get; set; }
        public string ValorPrato { get; set; }
    }

    public class MotoBoyViewModel
    {
        // Do motoboy mais próximos
        public int? Id { get; set; }

        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Distancia { get; set; }
        public string Data { get; set; }
        public dynamic MAPMotoboy { get; set; }

        // Todos os motoboys no mapa
        public List<LocalizacaoMotoboyViewModel> Localizacao { get; set; }

        // Dropdown dos motoboys
        public List<MotoboyViewModel> Motoboys { get; set; }

        public MotoBoyViewModel()
        {
            Localizacao = new List<LocalizacaoMotoboyViewModel>();
            Motoboys = new List<MotoboyViewModel>();
        }
    }

    public class LocalizacaoMotoboyViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Distancia { get; set; }
        public string Data { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class MotoboyViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}