using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public int? CadastroCompleto { get; set; }
        public int? Ativo { get; set; }

        public virtual System.Collections.Generic.ICollection<Estoque> Estoque { get; set; }

        public FornecedorViewModel()
        {
            DataCriacao = System.DateTime.Now;
            Estoque = new System.Collections.Generic.List<Estoque>();
        }
    
}
}