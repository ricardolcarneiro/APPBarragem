using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class MovimentoFinanceiroViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? FornecedorId { get; set; }
        public int? EstCategoriaId { get; set; }
        public double? Valor { get; set; }
        public string NotaFiscal { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public int? TipoMovimento { get; set; }
        public int? Pago { get; set; }
        public int? UsuarioId { get; set; }
        public System.DateTime? DataVencimento { get; set; }
        public string AnexoImagem { get; set; }

        public HttpPostedFileBase File { get; set; }
        public virtual EstCategoria EstCategoria { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual Usuario Usuario { get; set; }

        public MovimentoFinanceiroViewModel()
        {
            DataCriacao = System.DateTime.Now;
        }

   
        public virtual IEnumerable<MovimentoFinanceiro> lstMovimentoFinanceiro { get; set; }
        
    }
}