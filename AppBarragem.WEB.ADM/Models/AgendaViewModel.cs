using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class AgendaViewModel
    {
        public int Id { get; set; }
        public System.DateTime? DataPedido { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public int? UsuarioId { get; set; }
        public int? EmpresaId { get; set; }
        public int? EventId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool? IsFullDay { get; set; }
        public int? ProdutoId { get; set; }
        //public List<Produto> Produto { get; set; }

        public virtual System.Collections.Generic.ICollection<Pedido> Pedido { get; set; }

    }
}