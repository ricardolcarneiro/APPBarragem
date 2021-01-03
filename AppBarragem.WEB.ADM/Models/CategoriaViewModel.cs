using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public int? PracaId { get; set; }

        public HttpPostedFileBase File { get; set; }
        public virtual System.Collections.Generic.ICollection<ProdutoAdmViewModel> Produto { get; set; }


        public virtual PracaAdmViewModel Praca { get; set; }

        public CategoriaViewModel()
        {
            Ativo = true;
            DataCriacao = System.DateTime.Now;
            Produto = new System.Collections.Generic.List<ProdutoAdmViewModel>();
        }
    }
}