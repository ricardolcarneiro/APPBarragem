//using AppBarragem.DAL.Marmita.Context;
using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class CarteiraAdmViewModel
    {
        public int Id { get; set; }
        public double SaldoAtual { get; set; }
        public double? PagamentoPendenteDebito { get; set; }
        public double? PagamentoPendenteCredito { get; set; }


        //public virtual Cliente Cliente { get; set; }

        public CarteiraAdmViewModel()
        {
            //Cliente = new Cliente();
        }
    }
}