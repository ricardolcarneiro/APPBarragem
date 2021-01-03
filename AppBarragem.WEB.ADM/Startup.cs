using AppBarragem.Utils;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartupAttribute(typeof(AppBarragem.WEB.ADM.Startup))]
namespace AppBarragem.WEB.ADM
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = Constantes.IDENTITY_UUID,
                LoginPath = new PathString("/Login/Login")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
