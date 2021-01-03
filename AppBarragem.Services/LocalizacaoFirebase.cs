using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBarragem.Services
{
    public class LocalizacaoFirebase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string DataAtualizacao { get; set; }
        public double Distancia { get; set; }
    }
}