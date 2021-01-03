using ZeNerd.DAL.Context;
using AppBarragem.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc;

namespace AppBarragem.WEB.ADM.Util
{
    public static class Constantes
    {

        public static string URL_IMAGEM = @"http://www.gesconv.com.br/appbarragem/Content/Imagem/";

        // Sempre vai pegar o Id so usuário logado na sessão
        public static int GetUserId(this ControllerBase controller)
        {
            var id = -1;
            var claims = ClaimsPrincipal.Current.Claims.ToList();

            if (claims.Any())
            {
                id = int.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }

            return id;
        }



        // kkk
        // no caso é só mudar o retorno pra int
        // qual o nome do id... alias
        // iomaginiokk

        public static string GetUserImage(this ControllerBase controller)
        {
            var image = string.Empty;
            var claims = ClaimsPrincipal.Current.Claims.ToList();

            if (claims.Any())
            {
                image = claims.FirstOrDefault(x => x.Type == ClaimTypes.Thumbprint).Value;
            }

            return image;
        }

        // isso

        public static List<Usuario> MOTOBOY = new List<Usuario>();
        public static Usuario USUARIO_LOGADO = new Usuario();

        public enum TipoMensagem
        {
            Alerta,
            Atencao,
            Sucesso
        }

        //public static string ALERTA()
        //{
        //    DatabaseContext db = new DatabaseContext();
        //    int intMinutos = db.TempoLimite.FirstOrDefault().Minutos;

        //    List<Pedido> pedidos = db.Pedido.Where(i => i.Status == (int)TipoPedido.Solicitado).OrderBy(i => i.DataPedido).ToList();

        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("      <li id=\"notification\" class=\"dropdown notifications-menu\">");
        //    sb.AppendLine("                    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">");
        //    sb.AppendLine("                        <i class=\"fa fa-bell-o\"></i>");
        //    sb.AppendLine("                        <span class=\"label label-warning\">" + pedidos.Count() + "</span>");
        //    sb.AppendLine("                    </a>");
        //    sb.AppendLine("                    <ul class=\"dropdown-menu\">");
        //    sb.AppendLine("                        <li class=\"header\">You have " + pedidos.Count() + " notifications</li>");
        //    sb.AppendLine("                        <li>");
        //    sb.AppendLine("                            <!-- inner menu: contains the actual data -->");
        //    sb.AppendLine("                            <ul class=\"menu\">");

        //    foreach (var item in pedidos)
        //    {
        //        sb.AppendLine("                                <li>");
        //        sb.AppendLine("                                    <a href=\"#\">");
        //        sb.AppendLine("                                        <i class=\"fa fa-users text-aqua\"></i> Número do pedido:" + item.NumeroPedido + "");
        //        sb.AppendLine("                                    </a>");
        //        sb.AppendLine("                                </li>");
        //        sb.AppendLine("<iframe src=\"https://admin.mamelukos.com.br/Content/Sound/deseoAlarme.mp3\" allow=\"autoplay\" style=\"display:none\" id=\"iframeAudio\"></iframe>");

        //        if (DateTime.Now >= item.DataPedido.Add(new TimeSpan(0, 0, intMinutos, 0)))
        //        {
        //            sb.AppendLine("<iframe src=\"https://admin.mamelukos.com.br/Content/Sound/deseoAlarme.mp3\" allow=\"autoplay\" style=\"display:none\" id=\"iframeAudio\"></iframe>");
        //            item.Status = (int)TipoPedido.Atrasado;
        //            db.Pedido.AddOrUpdate(item);
        //            db.SaveChanges();
        //        }
        //    }

        //    sb.AppendLine("                            </ul>");
        //    sb.AppendLine("                        </li>");
        //    sb.AppendLine("                        <li class=\"footer\"><a href=\"../ControlePedido/Index\">Ver controle pedidos </a></li>");
        //    sb.AppendLine("                    </ul>");
        //    sb.AppendLine("                </li>");
        //    //sb.AppendLine("  <script type=\"text/javascript\">");
        //    //sb.AppendLine("        $(function () {");
        //    //sb.AppendLine("            setInterval(function () { $('#notification').load('/Home/Notificacao'); }, 10000); // every 3 sec");
        //    //sb.AppendLine("        });");
        //    //sb.AppendLine("    </script>");

        //    return sb.ToString();
        //}

        public static string TratarMensagem(TipoMensagem tipoMensagem, string mensagem)
        {
            StringBuilder sb = new StringBuilder();
            switch (tipoMensagem)
            {
                case TipoMensagem.Alerta:

                    sb = new StringBuilder();

                    sb.AppendLine("<div class=\"alert alert-danger alert-dismissible\" style=\"position:fixed;width: 89.9%;z-index:99;");
                    sb.AppendLine("    margin: -21% 0% 0% 0%;\">");
                    sb.AppendLine("    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>");
                    sb.AppendLine("    <h4><i class=\"icon fa fa-ban\"></i> Alerta!</h4>");
                    sb.AppendLine("    ");
                    sb.AppendLine(mensagem.ToString());
                    sb.AppendLine("</div>");

                    return sb.ToString();

                case TipoMensagem.Atencao:
                    sb = new StringBuilder();

                    sb.AppendLine("<div class=\"alert alert-warning alert-dismissible\" style=\"position:fixed;width: 89.9%;z-index:99;");
                    sb.AppendLine("    margin: -21% 0% 0% 0%;\">");
                    sb.AppendLine("    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>");
                    sb.AppendLine("    <h4><i class=\"icon fa fa-ban\"></i> Atenção!</h4>");
                    sb.AppendLine("    ");
                    sb.AppendLine(mensagem.ToString());
                    sb.AppendLine("</div>");

                    return sb.ToString();

                case TipoMensagem.Sucesso:

                    sb = new StringBuilder();

                    sb.AppendLine("<div class=\"alert alert-success alert-dismissible\" style=\"position:fixed;width: 89.9%;z-index:99;");
                    sb.AppendLine("    margin: -21% 0% 0% 0%;\">");
                    sb.AppendLine("    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>");
                    sb.AppendLine("    <h4><i class=\"icon fa fa-ban\"></i> Sucesso!</h4>");
                    sb.AppendLine("    ");
                    sb.AppendLine(mensagem.ToString());
                    sb.AppendLine("</div>");

                    return sb.ToString();
            }

            return sb.ToString();
        }
    }
}