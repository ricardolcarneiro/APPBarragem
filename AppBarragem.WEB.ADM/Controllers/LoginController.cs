using ZeNerd.DAL.Context;
using AppBarragem.Utils;
using AppBarragem.WEB.ADM.Util;
using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppBarragem.WEB.ADM.Controllers
{
    //[WebAuthorize(TipoUsuario.Admin, TipoUsuario.SuperAdmin)]

    public class LoginController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private Usuario objUsuario;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult Reiniciar()
        {
            return View();
        }

        public async Task<ActionResult> EnviarSenha(Usuario model)
        {
            model = db.Usuario.Where(i => i.Email == model.Email).FirstOrDefault();

            //connection = new EmailConnection(Suporte.Email, Suporte.Senha, Suporte.Host, Suporte.Porta, Suporte.SSL);

            ResgatarSenha(model.Email, model.Nome, model.Senha);
            //Services.EnviarEmail.RecuperarSenha(model.Email, model.Nome, model.Senha);

            return View("Index");
        }

        public static void ResgatarSenha(string EmailTo, string Nome, string Senha)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(EmailTo);
            mail.From = new MailAddress(Suporte.Email);
            mail.Subject = "[Mamelukos] Recuperação de senha - " + DateTime.Now.ToString();
            mail.Body = $@"
                            <!DOCTYPE html>
                            <html lang='pt-br' xmlns='http://www.w3.org/1999/xhtml'>
                            <head>
                                <meta charset='utf-8' />
                                <title>Mamelukos</title>
                                <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css' rel='stylesheet'>
                            </head>
                            <body style='width: 720px; margin: auto;'>
                                <div style='padding: 24px; background-color: white; text-align: center;'>
                                    <img src='' />
                                    <hr style='background-color: #E5312A; border-color: #E5312A; color: #E5312A;' />
                                </div>
                                <div>
                                    <p style='margin: 24px 48px; color: #E5312A;'>Olá, <strong>{Nome}</strong></p>
                                    <div style='font-weight: bold; background-color: #00A859; color: white;'>
                                        <p style='margin: 24px 48px; padding: 16px 0px; line-height: 2;'>
                                            Foi solicitado uma recuperação de senha para esta conta.
                                            <br />
                                            Sua nova senha é: {Senha}
                                        </p>
                                    </div>
                                    <p style='margin: 24px 48px; color: #E5312A; line-height: 2;'>
                                        Atenciosamente,
                                        <br />
                                        <strong>Equipe Mamelukos</strong>
                                    </p>
                                </div>
                            </body>
                            </html>
                            ";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(Suporte.Host, Suporte.Porta);
            smtp.EnableSsl = Suporte.SSL;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(Suporte.Email, Suporte.Senha);
            smtp.Send(mail);
        }

        //        public static async Task<bool> RecuperarSenha(string email, string nome, string senha)
        //        {
        //            var body = $@"
        //<!DOCTYPE html>
        //<html lang='pt-br' xmlns='http://www.w3.org/1999/xhtml'>
        //<head>
        //    <meta charset='utf-8' />
        //    <title>Mamelukos</title>
        //    <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css' rel='stylesheet'>
        //</head>
        //<body style='width: 720px; margin: auto;'>
        //    <div style='padding: 24px; background-color: white; text-align: center;'>
        //        <img src='' />
        //        <hr style='background-color: #E5312A; border-color: #E5312A; color: #E5312A;' />
        //    </div>
        //    <div>
        //        <p style='margin: 24px 48px; color: #E5312A;'>Olá, <strong>{nome}</strong></p>
        //        <div style='font-weight: bold; background-color: #00A859; color: white;'>
        //            <p style='margin: 24px 48px; padding: 16px 0px; line-height: 2;'>
        //                Foi solicitado uma recuperação de senha para esta conta.
        //                <br />
        //                Sua nova senha é: {senha}
        //            </p>
        //        </div>
        //        <p style='margin: 24px 48px; color: #E5312A; line-height: 2;'>
        //            Atenciosamente,
        //            <br />
        //            <strong>Equipe Mamelukos</strong>
        //        </p>
        //    </div>
        //</body>
        //</html>
        //";
        //            return (await connection.SendHtml(email, "[Mamelukos] Recuperação de senha", body)).IsSuccess;
        // é só referenciar qual a classe pra tirar a ambiguidade
        //        }

        // GET: Login
        public ActionResult Sair()
        {
            Request.GetOwinContext().Authentication.SignOut(Utils.Constantes.IDENTITY_UUID);
            var AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            AuthenticationManager.SignOut();
            return RedirectToAction("../Login/Index");
        }

        // vc criar um contlher home pso pra chamar essas constantes
        // a view vai chamar essa Action, que vai retornar a url
        // pode chamar em qualquer lugar... é só vc reerenciar o controlhe e a action
        public string UrlImagem()
        {
            //return string.Empty;
            return this.GetUserImage();
        }

        // GET: Login
        public async System.Threading.Tasks.Task<ActionResult> Login(Usuario model)
        {
            Usuario usuario = db.Usuario.ToList().Where(i => (i.Login == model.Login) && (i.Senha == Utils.Constantes.SHA1Encode(model.Senha))).FirstOrDefault();



            if (usuario != null)
            {
                //Constantes.USER_LOCAL_IMAGEM = usuario.Foto;
                //Util.Constantes.USUARIO_LOGADO = usuario;
                var identity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Thumbprint, usuario.Foto),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), //should be userid
                 new Claim(ClaimTypes.Role,  VerificaRegraAcesso(usuario.TipoUsuario.ToString()))
            }, "ApplicationCookie");

                Request.GetOwinContext().Authentication.SignOut(Utils.Constantes.IDENTITY_UUID);
                Request.GetOwinContext().Authentication.SignIn(identity);

                return RedirectToAction("../Home/Index");
            }
            else
            {
                TempData.Add("ATENCAO",
          "O usuário ou senha estão inválidos!");
                return RedirectToAction("/Index");
            }
        }

        private string VerificaRegraAcesso(string tipo)
        {
            switch (tipo)
            {
                case "0":
                    return "SuperAdmin";

                case "1":
                    return "Admin";

                case "2":
                    return "User";

                default:
                    return "User";
            }
        }
    }
}