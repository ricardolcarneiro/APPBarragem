using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class UsuarioAdmViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public byte[] DataAtualizacao { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public HttpPostedFileBase File { get; set; }


        public UsuarioAdmViewModel()
        {
            Ativo = true;
            DataCriacao = System.DateTime.Now;

        }
    }


}

