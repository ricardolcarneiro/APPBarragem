using ZeNerd.DAL.Context;
//using AppBarragem.DAL.Marmita.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class EmailMarketingViewModel
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public System.DateTime? DateCriacao { get; set; }

        public int? ClienteId { get; set; }
        //public virtual System.Collections.Generic.ICollection<Cliente> Cliente { get; set; }


        public HttpPostedFileBase File { get; set; }

      


        public EmailMarketingViewModel()
        {
            DateCriacao = System.DateTime.Now;
        }
    }


}

