using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class IngredienteAdmViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public int ProdutoId { get; set; }
        public double? PesoTotal { get; set; }
        public double? Ic { get; set; }
        public double? Pl { get; set; }
        public double? Fc { get; set; }
        public double? Pb { get; set; }
        public double? Kcal { get; set; }
        public double? Ptn { get; set; }
        public double? Cho { get; set; }
        public double? Lip { get; set; }
        public double? Custo { get; set; }
        public string MedidaCaseira { get; set; }
        public HttpPostedFileBase File { get; set; }
        public virtual System.Collections.Generic.ICollection<TipoQuantidade> TipoQuantidade { get; set; }

        public virtual List<Ingrediente> lstIngrediente { get; set; }
        public virtual ProdutoAdmViewModel Produto { get; set; }

        public IngredienteAdmViewModel()
        {
            Ativo = true;
            DataCriacao = System.DateTime.Now;
            PesoTotal = 0;
            Ic = 0;
            Pl = 0;
            Fc = 0;
            Ptn = 0;
            Lip = 0;
            Pb = 0;
            Kcal = 0;
            Cho = 0;
            Custo = 0;
            TipoQuantidade = new System.Collections.Generic.List<TipoQuantidade>();
            lstIngrediente = new List<Ingrediente>();

        }
    }


}

