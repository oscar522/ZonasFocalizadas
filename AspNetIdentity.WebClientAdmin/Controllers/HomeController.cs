using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize] 
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            string IdRol = GetTokenObject().role;
            string ViewPage = "";
            string Controller = "";
            if (IdRol == "Invitado" || IdRol == "Otros" || IdRol == "User")
            {
                ViewPage = "BuscarExpedientes";
                Controller = "HomeUsuarios";
            }
            else {
                ViewPage = "Index";
                Controller = "Dashboard";
            }
            

            return RedirectToAction(ViewPage, Controller);
        }

        public ActionResult IndexCv()
        {
            return View();
        }

        public ActionResult IndexPerfil()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}