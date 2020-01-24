using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClient.Controllers
{
    public class LayoutController : BaseController
    {
        // GET: Layout
        public ActionResult Sidebar()
        {
            return PartialView();
        }

        public ActionResult Navbar()
        {
            return PartialView();
        }
    }
}