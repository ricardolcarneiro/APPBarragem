//using AppBarragem.DAL.Marmita.Context;
using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class SiteProdutoAdmViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public double Preco { get; set; }
        public int Ordem { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public int CategoriaId { get; set; }
        public int Quantidade { get; set; }
        public HttpPostedFileBase File { get; set; }
        public virtual System.Collections.Generic.ICollection<ProdutoPedido> ProdutoPedido { get; set; }
        public bool? FlagMarmita { get; set; }

        public virtual Categoria Categoria { get; set; }

        public SiteProdutoAdmViewModel()
        {
            Ordem = 0;
            Ativo = true;
            DataCriacao = System.DateTime.Now;
            Quantidade = 0;
            ProdutoPedido = new System.Collections.Generic.List<ProdutoPedido>();
        }
    }


}

