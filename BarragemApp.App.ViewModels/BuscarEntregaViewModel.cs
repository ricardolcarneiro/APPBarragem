namespace BarragemApp.App.ViewModels
{
    public class BuscarEntregaViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Telefone { get; set; }
        public string NumeroPedido { get; set; }
        public string Total { get; set; }
        public string Pagamento { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}