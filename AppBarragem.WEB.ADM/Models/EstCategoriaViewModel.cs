using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class EstCategoriaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual System.Collections.Generic.ICollection<MovimentoFinanceiroViewModel> Estoque { get; set; }

        public EstCategoriaViewModel()
        {
            Estoque = new System.Collections.Generic.List<MovimentoFinanceiroViewModel>();
        }
    }
}