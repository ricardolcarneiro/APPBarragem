using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class PracaAdmViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }


        public HttpPostedFileBase File { get; set; }
        public virtual System.Collections.Generic.ICollection<CategoriaViewModel> Categoria { get; set; }

        public PracaAdmViewModel()
        {
            Ativo = true;
            DataCriacao = System.DateTime.Now;
            Categoria = new System.Collections.Generic.List<CategoriaViewModel>();
        }
    }

}

