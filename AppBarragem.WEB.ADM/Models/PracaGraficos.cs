using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarragem.WEB.ADM.Models
{
    public class PracaGraficos
    {
        private int id;
        private string nome;
        private string count;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Count { get => count; set => count = value; }
    }
}