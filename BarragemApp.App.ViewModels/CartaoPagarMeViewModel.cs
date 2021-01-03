namespace BarragemApp.App.ViewModels
{
    public class CartaoPagarMeViewModel
    {
        public int ClienteId { get; set; }
        public string UltimosDigitos { get; set; }
        public string Bandeira { get; set; }
        public string PagarMeId { get; set; }
        public bool Valido { get; set; }
    }
}