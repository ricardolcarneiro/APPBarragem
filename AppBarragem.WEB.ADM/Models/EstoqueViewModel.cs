using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class EstoqueViewModel
    {
        public int Id { get; set; }
        public int? CodigoProduto { get; set; }
        public string Nf { get; set; }
        public int? Quantidade { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public decimal? ValorUnidade { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? FornecedorId { get; set; }
        public string Produto { get; set; }
        public int? UnidadeId { get; set; }


        //public virtual DAL.Context.Fornecedor Fornecedor { get; set; }

        //public virtual TipoUnidade TipoUnidade { get; set; }

        public EstoqueViewModel()
        {
            DataCriacao = System.DateTime.Now;
        }
    }
}