using ZeNerd.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class EntregadorViewModel
  
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int TipoUsuario { get; set; }
        public string UrlFotoCnh { get; set; }
        public string UrlFotoSelfie { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Digito { get; set; }
        public int StatusCadastro { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public string Foto { get; set; }
        //public HttpPostedFileBase File { get; set; }
        //public virtual System.Collections.Generic.ICollection<Localizacao> Localizacao { get; set; }
        //public virtual System.Collections.Generic.ICollection<Log> Log { get; set; }
        //public virtual System.Collections.Generic.ICollection<MovimentoFinanceiro> MovimentoFinanceiro { get; set; }
        //public virtual System.Collections.Generic.ICollection<Pedido> Pedido { get; set; }

        public EntregadorViewModel()
        {
            StatusCadastro = 0;
            Ativo = true;
            DataCriacao = System.DateTime.Now;
            Localizacao = new System.Collections.Generic.List<Localizacao>();
            Log = new System.Collections.Generic.List<Log>();
            MovimentoFinanceiro = new System.Collections.Generic.List<MovimentoFinanceiro>();
            Pedido = new System.Collections.Generic.List<Pedido>();
        }
    }

}
// </auto-generated>
