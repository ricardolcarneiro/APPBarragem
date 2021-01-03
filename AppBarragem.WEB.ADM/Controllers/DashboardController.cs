using Mamelucos.Utils;
using Mamelucos.WEB.ADM.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mamelucos.WEB.ADM.Controllers
{
    [WebAuthorize(TipoUsuario.Admin, TipoUsuario.SuperAdmin)]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboardv1()
        {
            return View();
        }

        public ActionResult Dashboardv2()
        {
            return View();
        }
    }
}