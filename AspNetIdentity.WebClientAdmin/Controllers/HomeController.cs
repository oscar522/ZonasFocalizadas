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

            if (IdRol.Equals("Administrator"))
            {
                ViewPage = "Index";
                Controller = "HomeAdministrator";
            }
            else if (IdRol.Equals("Abogados"))
            {
                ViewPage = "Index";
                Controller = "HomeTipificacion";
            }
            else if (IdRol.Equals("User"))
            {
                ViewPage = "Index";
                Controller = "HomeTipificacion";
            }
            else if (IdRol.Equals("Agronomo"))
            {
                ViewPage = "Index";
                Controller = "HomeTipificacion";
            }
            else if (IdRol.Equals("Catastral"))
            {
                ViewPage = "Index";
                Controller = "HomeTipificacion";
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