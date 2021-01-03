using AppBarragem.Utils;

using System;

namespace BarragemApp.App.ViewModels
{
    public class CupomViewModel
    {
        public int Id { get; set; }
        public double Desconto { get; set; }
        public string Codigo { get; set; }
        public TipoCupom Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}