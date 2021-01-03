using System;
using System.Collections.Generic;
using System.Text;

namespace AppBarragem.VO
{
    public class RotaDestino
    {
        public long Id { get; set; }
        public string Endereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Zoom { get; set; }
        public long? UsuarioId { get; set; }
        public string Data { get; set; }
    }
}
