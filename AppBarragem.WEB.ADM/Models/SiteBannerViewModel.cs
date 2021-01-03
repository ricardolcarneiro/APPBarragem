using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class SiteBannerViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DescricaoMobile { get; set; }
        public string Link { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public HttpPostedFileBase File { get; set; }
        public HttpPostedFileBase FileMobile { get; set; }

        public SiteBannerViewModel()
        {
            Ativo = true;
            DataCriacao = System.DateTime.Now;
         
        }
    }
}