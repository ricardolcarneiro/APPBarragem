using System.Linq;
using System.Web.Mvc;

namespace AppBarragem.WEB.ADM.Filters
{
    public class WebAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly object[] roles;

        public WebAuthorizeAttribute(params object[] roles)
        {
            this.roles = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var IsAuthorized = roles.Any(x => filterContext.HttpContext.User.IsInRole(x.ToString()));

            if (!IsAuthorized)
            {
                var ReturnUrl = "~/Home/Index";

                filterContext.Result = new RedirectResult(ReturnUrl);
            }
        }
    }
}