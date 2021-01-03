using AppBarragem.Utils;
using AppBarragem.WEB.ADM.Filters;
//using AppBarragem.WEB.ADM.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZeNerd.DAL.Context;

namespace AppBarragem.WEB.ADM.Controllers
{
    [WebAuthorize(TipoUsuario.Admin, TipoUsuario.SuperAdmin)]
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private StringBuilder conteudo;
        private StringBuilder pinPedido;
        //private List<Pedido> pedidos;
        //private List<Pedido> lstPedidos;
        //private List<Pedido> lstPedidosMarmita;
        //private List<Produto> lstProduto;
        //private List<ProdutoPedido> lstProdutoPedido;
        //private List<Categoria> lstCategoria;
        //private List<Praca> lstPraca;
        //private List<Praca> lstPracaTratado;
        //private List<PracaGraficos> lstPracaGraficos;
        private int lstPedidosSolicitado;
        private int lstPedidosEmAndamento;
        private int lstPedidosPronto;
        private int lstPedidosAtrasado;
        private Random rnd;
        private Random rnd2;
        private Color randomColor2;
        private Color randomColor;
        //private List<Pedido> lstPedidosApp;
        //private List<Pedido> lstPedidosAndamento;
        //private List<Pedido> lstPedidosPratoPronto;
        //private List<Pedido> lstPedidosGeral;
        //private List<Pedido> lstPedidosCancelado;
        //private List<Pedido> lstPedidosEntregue;



        public async Task<ActionResult> Index()
        {

            List<Morador> lstMorador = db.Morador.ToList();
            conteudo = new StringBuilder();

            foreach (var item in lstMorador)
            {


                conteudo.AppendLine("  ['<div style=\"width:200px;margin:0 auto; color:#4E1361;\"><h4><b>ID:" + item.Id + "</b></h4><br>Telefone:" + item.Telefone + "<br> <br>Morador:" + item.Nome + "<br>  </div>', " + item.Latitude.ToString().Replace(",", ".")

                     + ", " + item.Longitude.ToString().Replace(",", ".") + "],");
            }
            ViewBag.MAPSolicitado = conteudo;
            ViewBag.MORADORES = lstMorador.Count().ToString();
            return View();
        }

        private void CarregaPorcentagem()
        {

            //lstPedidos = db.Pedido.Include(p => p.Cartao).Include(p => p.Cliente).Include(p => p.ProdutoPedido).ToList();
            //lstPedidosAndamento = lstPedidos.Where(i => i.Status == (int)TipoPedido.EmAndamento).ToList();
            //lstPedidosPratoPronto = lstPedidos.Where(i => i.Status == (int)TipoPedido.Pronto).ToList();
            //lstPedidosGeral = lstPedidos.ToList();
            //lstPedidosEntregue = lstPedidos.Where(i => i.Status == (int)TipoPedido.Entregue).ToList();
            //lstPedidosCancelado = lstPedidos.Where(i => i.Status == (int)TipoPedido.Cancelado).ToList();


            //int intPedidosAndamento = 0;
            //int intPedidosPronto = 0;
            ////int intPedidosGeral = (lstPedidosMarmita.Count() * 100) / lstPedidosGeral.Count();
            //int intPedidosCancelado = 0;
            //int intPedidosEntregue = 0;

            //if (lstPedidosGeral.Count < 0)
            //{
            //     intPedidosAndamento = (lstPedidosAndamento.Count() * 100) / lstPedidosGeral.Count();
            //     intPedidosPronto = (lstPedidosPratoPronto.Count() * 100) / lstPedidosGeral.Count();
            //    //int intPedidosGeral = (lstPedidosMarmita.Count() * 100) / lstPedidosGeral.Count();
            //     intPedidosCancelado = (lstPedidosCancelado.Count() * 100) / lstPedidos.Count();
            //     intPedidosEntregue = (lstPedidosEntregue.Count() * 100) / lstPedidos.Count();
            //}


            //    StringBuilder sb = new StringBuilder();

            //    sb.AppendLine("    <ul class=\"dropdown-menu\">");
            //    sb.AppendLine("                        <li class=\"header\">São " + lstPedidos.Count().ToString() + " pedidos</li>");
            //    sb.AppendLine("                        <li>");
            //    sb.AppendLine("                            <!-- inner menu: contains the actual data -->");
            //    sb.AppendLine("                            <ul class=\"menu\">");
            //    sb.AppendLine("                                <li>");
            //    sb.AppendLine("                                    <!-- Task item -->");
            //    sb.AppendLine("                                    <a href=\"#\">");
            //    sb.AppendLine("                                        <h3>");
            //    sb.AppendLine("                                            Pratos Pronto");
            //    sb.AppendLine("                                            <small class=\"pull-right\">" + intPedidosPronto.ToString() + "%</small>");
            //    sb.AppendLine("                                        </h3>");
            //    sb.AppendLine("                                        <div class=\"progress xs\">");
            //    sb.AppendLine("                                            <div class=\"progress-bar progress-bar-aqua\" style=\"width: " + intPedidosPronto.ToString() + "%\" role=\"progressbar\"");
            //    sb.AppendLine("                                                 aria-valuenow=\"" + intPedidosPronto.ToString() + "\" aria-valuemin=\"0\" aria-valuemax=\"100\">");
            //    sb.AppendLine("                                                <span class=\"sr-only\">" + intPedidosPronto.ToString() + "% Complete</span>");
            //    sb.AppendLine("                                            </div>");
            //    sb.AppendLine("                                        </div>");
            //    sb.AppendLine("                                    </a>");
            //    sb.AppendLine("                                </li>");
            //    sb.AppendLine("                                <!-- end task item -->");
            //    sb.AppendLine("                                <li>");
            //    sb.AppendLine("                                    <!-- Task item -->");
            //    sb.AppendLine("                                    <a href=\"#\">");
            //    sb.AppendLine("                                        <h3>");
            //    sb.AppendLine("                                           Pratos em Andamento");
            //    sb.AppendLine("                                            <small class=\"pull-right\">" + intPedidosAndamento.ToString() + "%</small>");
            //    sb.AppendLine("                                        </h3>");
            //    sb.AppendLine("                                        <div class=\"progress xs\">");
            //    sb.AppendLine("                                            <div class=\"progress-bar progress-bar-green\" style=\"width: " + intPedidosAndamento.ToString() + "%\" role=\"progressbar\"");
            //    sb.AppendLine("                                                 aria-valuenow=\"" + intPedidosAndamento.ToString() + "\" aria-valuemin=\"0\" aria-valuemax=\"100\">");
            //    sb.AppendLine("                                                <span class=\"sr-only\">" + intPedidosAndamento.ToString() + "% Complete</span>");
            //    sb.AppendLine("                                            </div>");
            //    sb.AppendLine("                                        </div>");
            //    sb.AppendLine("                                    </a>");
            //    sb.AppendLine("                                </li>");
            //    sb.AppendLine("                                <!-- end task item -->");
            //    sb.AppendLine("                                <li>");
            //    sb.AppendLine("                                    <!-- Task item -->");
            //    sb.AppendLine("                                    <a href=\"#\">");
            //    sb.AppendLine("                                        <h3>");
            //    sb.AppendLine("                                            Pratos em Cancelamento");
            //    sb.AppendLine("                                            <small class=\"pull-right\">" + intPedidosCancelado.ToString() + "%</small>");
            //    sb.AppendLine("                                        </h3>");
            //    sb.AppendLine("                                        <div class=\"progress xs\">");
            //    sb.AppendLine("                                            <div class=\"progress-bar progress-bar-red\" style=\"width: " + intPedidosCancelado.ToString() + "%\" role=\"progressbar\"");
            //    sb.AppendLine("                                                 aria-valuenow=\"" + intPedidosCancelado.ToString() + "\" aria-valuemin=\"0\" aria-valuemax=\"100\">");
            //    sb.AppendLine("                                                <span class=\"sr-only\">" + intPedidosCancelado.ToString() + "% Complete</span>");
            //    sb.AppendLine("                                            </div>");
            //    sb.AppendLine("                                        </div>");
            //    sb.AppendLine("                                    </a>");
            //    sb.AppendLine("                                </li>");
            //    sb.AppendLine("                                <!-- end task item -->");
            //    sb.AppendLine("                                <li>");
            //    sb.AppendLine("                                    <!-- Task item -->");
            //    sb.AppendLine("                                    <a href=\"#\">");
            //    sb.AppendLine("                                        <h3>");
            //    sb.AppendLine("                                            Pratos em Entregues");
            //    sb.AppendLine("                                            <small class=\"pull-right\">" + intPedidosEntregue.ToString() + "%</small>");
            //    sb.AppendLine("                                        </h3>");
            //    sb.AppendLine("                                        <div class=\"progress xs\">");
            //    sb.AppendLine("                                            <div class=\"progress-bar progress-bar-yellow\" style=\"width: " + intPedidosEntregue.ToString() + "%\" role=\"progressbar\"");
            //    sb.AppendLine("                                                 aria-valuenow=\"" + intPedidosEntregue.ToString() + "\" aria-valuemin=\"0\" aria-valuemax=\"100\">");
            //    sb.AppendLine("                                                <span class=\"sr-only\">" + intPedidosEntregue.ToString() + "% Complete</span>");
            //    sb.AppendLine("                                            </div>");
            //    sb.AppendLine("                                        </div>");
            //    sb.AppendLine("                                    </a>");
            //    sb.AppendLine("                                </li>");
            //    sb.AppendLine("                                <!-- end task item -->");
            //    sb.AppendLine("                            </ul>");
            //    sb.AppendLine("                        </li>");
            //    sb.AppendLine("                        <li class=\"footer\">");
            //    sb.AppendLine("                            <a href=\"../ControlePedido/Index\">Ver todos os pedidos</a>");
            //    sb.AppendLine("                        </li>");
            //    sb.AppendLine("                    </ul>");

            //    ViewBag.PORCENTAGEMPRATOS = sb.ToString();
            //}

            //        private void CarregaMapa()
            //        {
            //            conteudo = new StringBuilder();
            //            pinPedido = new StringBuilder();


            //            pinPedido.AppendLine("    <div class=\"img-perfil\">");
            //            pinPedido.AppendLine("    <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/p1.png\" title=\"Aisha\" alt=\"foto-perfil\"></div>");
            //            pinPedido.AppendLine("    <h1>Aisha</h1>");
            //cuidador.AppendLine("    <p>Project Manager</p>");
            //cuidador.AppendLine("    <hr>");
            //cuidador.AppendLine("    <h3>Activity Level : 85%</h3>");
            //cuidador.AppendLine("    <p>Lorem ipsum dolor sit amet consectetur</p>");
            //cuidador.AppendLine("    <div class=\"caja-gris\">");
            //cuidador.AppendLine("       <div class=\"sobre\">");
            //cuidador.AppendLine("           <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/msg.png\">");
            //cuidador.AppendLine("        <p>1086</p> ");
            //cuidador.AppendLine("      </div>");
            //cuidador.AppendLine("      <div class=\"sobre\">");
            //cuidador.AppendLine("           <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/p2.png\">");
            //cuidador.AppendLine("        <p>1582</p> ");
            //cuidador.AppendLine("      </div>");
            //cuidador.AppendLine("      <div class=\"sobre\">");
            //cuidador.AppendLine("           <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/p3.png\">");
            //cuidador.AppendLine("        <p>1468</p> ");
            //cuidador.AppendLine("      </div>");
            //cuidador.AppendLine("    </div> ");
            //cuidador.AppendLine("    ");
            //cuidador.AppendLine("      <div class=\"redes face\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("      <div class=\"redes twitter\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("      <div class=\"redes instagram\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("      <div class=\"redes youtube\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("     <div class=\"boton\">");
            //cuidador.AppendLine("					<a href=\"#\">Follow</a>");
            //cuidador.AppendLine("				</div> ");
            //cuidador.AppendLine("    ");
            //cuidador.AppendLine("    ");
            //cuidador.AppendLine("    ");
            //    pedidos = new List<Pedido>();

            //    pedidos = lstPedidos;

            //    int total = pedidos.Count;


            //    foreach (var item in lstPedidos.Where(i => i.Status == (int)TipoPedido.Solicitado))
            //    {


            //conteudo.AppendLine("  ['<div style=\"width:200px;margin:0 auto; color:#4E1361;\"><h4><b>ID:" + item.Id + "</b></h4><br>Numero Pedido:" + item.NumeroPedido + "<br> <br>Cliente:" + item.Cliente.Nome + "<br>  </div>', " + item.Lat.ToString().Replace(",", ".")

            //     + ", " + item.Lng.ToString().Replace(",", ".") + "],");
            //    }
            //    ViewBag.MAPSolicitado = conteudo;


            //    conteudo = new StringBuilder();

            //    foreach (var item in lstPedidos.Where(i => i.Status == (int)TipoPedido.EmAndamento))
            //    {
            ////conteudo.AppendLine("  ['<div style=\"width:200px;margin:0 auto; color:#4E1361;\"><h4><b>ID:" + item.Id + "</b></h4><br>Numero Pedido:" + item.NumeroPedido + "<br> <br>Cliente:" + item.Cliente.Nome + "<br><br><img   style=\"width:200px;margin:0 auto; color:#4E1361;\" src=\"../Content/Imagem/domar.jpg\" title=\"" + item.Id + "\" alt=\"foto-perfil\" ><br>  </div>', " + item.Lat.ToString().Replace(",", ".")


            //       conteudo.AppendLine("  ['<div style=\"width:200px;margin:0 auto; color:#4E1361;\"><h4><b>ID:" + item.Id + "</b></h4><br>Numero Pedido:" + item.NumeroPedido + "<br> <br>Cliente:" + item.Cliente.Nome + "<br>  </div>', " + item.Lat.ToString().Replace(",", ".")

            //            + ", " + item.Lng.ToString().Replace(",", ".") + "],");
            //    }
            //    ViewBag.MAPAguardando = conteudo;



            //    conteudo = new StringBuilder();

            //    foreach (var item in lstPedidos.Where(i => i.Status == (int)TipoPedido.Pronto))
            //    {


            //conteudo.AppendLine("  ['<div style=\"width:200px;margin:0 auto; color:#4E1361;\"><h4><b>ID:" + item.Id + "</b></h4><br>Numero Pedido:" + item.NumeroPedido + "<br> <br>Cliente:" + item.Cliente.Nome + "<br>  </div>', " + item.Lat.ToString().Replace(",", ".")

            //     + ", " + item.Lng.ToString().Replace(",", ".") + "],");
            //    }
            //    ViewBag.MAPPronto = conteudo;




            //    conteudo = new StringBuilder();

            //    foreach (var item in lstPedidos.Where(i => i.Status == (int)TipoPedido.Cancelado))
            //    {

            //conteudo.AppendLine("  ['<div style=\"width:200px;margin:0 auto; color:#4E1361;\"><h4><b>ID:" + item.Id + "</b></h4><br>Numero Pedido:" + item.NumeroPedido + "<br> <br>Cliente:" + item.Cliente.Nome + "<br>  </div>', " + item.Lat.ToString().Replace(",", ".")

            //     + ", " + item.Lng.ToString().Replace(",", ".") + "],");
            //    }
            ViewBag.MAPCancelado = conteudo;

        }


        public string GeraCorPraca(string praca)
        {
            if (praca == "Gourmet")
            {
                return "red";
            }
            if (praca == "Massas")
            {
                return "green";
            }
            if (praca == "Do Mar")
            {
                return "yellow";
            }
            if (praca == "Da Terra")
            {
                return "aqua";
            }

            if (praca == "Lanches")
            {
                return "aqua";
            }
            if (praca == "Da Terra")
            {
                return "blue";
            }
            if (praca == "Light")
            {
                return "gray";
            }
            if (praca == "Sobremesa")
            {
                return "fuchsia";
            }
            if (praca == "Asiático")
            {
                return "lime";
            }
            return "#A197B9";
        }
        public ActionResult _Mapa()
        {

            return View("~/Views/Shared/_Mapa.cshtml");
        }

        public ActionResult _PorcentagemPratos()
        {
            // BuildMyString.com generated code. Please enjoy your string responsibly.



            return View();

        }
        //[OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 10)] // every
        //public ActionResult Notificacao()

        //{



        //    //if (db.Pedido.Where(i => i.Status == (int)TipoPedido.Solicitado && i.FlagMarmita == false).ToList().Count > 0)
        //    //{
        //    //    Thread.Sleep(new TimeSpan(0, 0, 10));

        //    //    //StringBuilder sb = new StringBuilder();

        //    //    //sb.AppendLine("<iframe src=\"http://soundbible.com/mp3/Air Plane Ding-SoundBible.com-496729130.mp3\" allow=\"autoplay\" style=\"display:none\" id=\"iframeAudio\"></iframe>");

        //    //    //ViewBag.NOTIFICACAO = sb.ToString();
        //    //    return PartialView("_Notificacao");
        //    //}
        //    //else
        //    //{
        //    //    return PartialView("");
        //    //}





        //}

        [HttpGet]
        public ActionResult GetAudioFile()
        {
            string filePath = Server.MapPath(Url.Content($"~/Content/sounds/som.wav"));
            var bytes = new byte[0];
            var buff = new byte[0];

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var br = new BinaryReader(fs);
                long numBytes = new FileInfo(filePath).Length;
                buff = br.ReadBytes((int)numBytes);
            }

            return File(buff, "audio/wav", "som.wav");
        }


        //public ActionResult MovimentoFinanceiro()
        //{
        //    //List<MovimentoFinanceiro> lstMovimentoFinanceiro = db.MovimentoFinanceiro.Include(e => e.EstCategoria).Include(e => e.Fornecedor).Include(e => e.Usuario).ToListAsync().Result;


        //    var RENDIMENTO_TOTAL = Convert.ToDouble(lstMovimentoFinanceiro.Sum(i => i.Valor)).ToString("C", CultureInfo.CurrentCulture);
        //    var CUSTO_TOTAL = Convert.ToDouble(lstMovimentoFinanceiro.Where(i => i.Pago == 0).Sum(i => i.Valor)).ToString("C", CultureInfo.CurrentCulture);
        //    var LUCRO_TOTAL = Convert.ToDouble(lstMovimentoFinanceiro.Where(i => i.Pago == 1).Sum(i => i.Valor)).ToString("C", CultureInfo.CurrentCulture);

        //    ViewBag.RENDIMENTO_TOTAL = RENDIMENTO_TOTAL;
        //    ViewBag.CUSTO_TOTAL = CUSTO_TOTAL;
        //    ViewBag.LUCRO_TOTAL = LUCRO_TOTAL;

        //    //ViewBag.RENDIMENTO_TOTAL_PORCENTAGEM = (lstMovimentoFinanceiro.Where(i => i.Pago == 0).Count() * 100) / lstMovimentoFinanceiro.Count();

        //    if (lstMovimentoFinanceiro.Count < 0)
        //    {
        //        ViewBag.CUSTO_TOTAL_PORCENTAGEM = (lstMovimentoFinanceiro.Where(i => i.Pago == 0).Count() * 100) / lstMovimentoFinanceiro.Count();

        //        ViewBag.LUCRO_TOTAL_PORCENTAGEM = (lstMovimentoFinanceiro.Where(i => i.Pago == 1).Count() * 100) / lstMovimentoFinanceiro.Count();
        //    }
        //    else
        //    {
        //        ViewBag.CUSTO_TOTAL_PORCENTAGEM = 0;

        //        ViewBag.LUCRO_TOTAL_PORCENTAGEM = 0;
        //    }






        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("labels: ['" + DateTime.Now.Date.AddMonths(-3).ToString("MMMM") + "', '" + DateTime.Now.Date.AddMonths(-2).ToString("MMMM") + "', '" + DateTime.Now.Date.AddMonths(-1).ToString("MMMM") + "', '" + DateTime.Now.Date.ToString("MMMM") + "', '" + DateTime.Now.Date.AddMonths(1).ToString("MMMM") + "', '" + DateTime.Now.Date.AddMonths(2).ToString("MMMM") + "', '" + DateTime.Now.Date.AddMonths(3).ToString("MMMM") + "'],");
        //    sb.AppendLine("                 datasets: [");
        //    sb.AppendLine("                     {");
        //    sb.AppendLine("                         label: 'CUSTO TOTAL',");
        //    sb.AppendLine("                         fillColor: 'rgb(210, 214, 222)',");
        //    sb.AppendLine("                         strokeColor: 'rgb(210, 214, 222)',");
        //    sb.AppendLine("                         pointColor: 'rgb(210, 214, 222)',");
        //    sb.AppendLine("                         pointStrokeColor: '#c1c7d1',");
        //    sb.AppendLine("                         pointHighlightFill: '#fff',");
        //    sb.AppendLine("                         pointHighlightStroke: 'rgb(220,220,220)',");
        //    sb.AppendLine("                         data: [" + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 0 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(-3).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 0 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(-2).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 0 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 0 && i.DataCriacao.ToString("MM/yyyy").Equals(DateTime.Now.Date.ToString("MM/yyyy"))).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 0 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(1).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 0 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(2).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 0 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(3).ToString("MM/yyyy")).Sum(i => i.Valor)) + "]");
        //    sb.AppendLine("                     },");
        //    sb.AppendLine("                     {");
        //    sb.AppendLine("                         label: 'LUCRO TOTAL',");
        //    sb.AppendLine("                         fillColor: 'rgba(60,141,188,0.9)',");
        //    sb.AppendLine("                         strokeColor: 'rgba(60,141,188,0.8)',");
        //    sb.AppendLine("                         pointColor: '#3b8bba',");
        //    sb.AppendLine("                         pointStrokeColor: 'rgba(60,141,188,1)',");
        //    sb.AppendLine("                         pointHighlightFill: '#fff',");
        //    sb.AppendLine("                         pointHighlightStroke: 'rgba(60,141,188,1)',");
        //    sb.AppendLine("                         data: [" + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 1 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(-3).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 1 && i.DataCriacao == DateTime.Now.Date.AddMonths(-2)).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 1 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 1 && i.DataCriacao.ToString("MM/yyyy").Equals(DateTime.Now.Date.ToString("MM/yyyy"))).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 1 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(1).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 1 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(2).ToString("MM/yyyy")).Sum(i => i.Valor)) + ", " + Convert.ToInt32(lstMovimentoFinanceiro.Where(i => i.Pago == 1 && i.DataCriacao.ToString("MM/yyyy") == DateTime.Now.Date.AddMonths(3).ToString("MM/yyyy")).Sum(i => i.Valor)) + "]");

        //    sb.AppendLine("                     }");
        //    sb.AppendLine("                 ]");



        //    ViewBag.MontarGrafico = sb.ToString();

        //    return View(lstMovimentoFinanceiro);
        //}


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public void MontarGraficoChart()
        {

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}