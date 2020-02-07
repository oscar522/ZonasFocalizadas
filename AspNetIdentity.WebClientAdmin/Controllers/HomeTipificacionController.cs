using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize] 
    public class HomeTipificacionController : BaseController
    {
        private EmployeeProvider _employeeProvider;

        EmployeeProvider employeeProvider
        {
            get
            {
                if (_employeeProvider == null)
                {
                    _employeeProvider = new EmployeeProvider(bearerToken);
                }
                return _employeeProvider;
            }
            set
            {
                _employeeProvider = value;
            }
        }

        public async Task<ActionResult> Count()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalCount";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            int processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(jsonResult.ToString());
            return Json(processModel);
        }

        public async Task<ActionResult> CountEdit()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalCountEdit";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            int processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(jsonResult.ToString());
            return Json(processModel);
        }

        public async Task<ActionResult> CountMalNombrados()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalCountMal";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            int processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(jsonResult.ToString());
            return Json(processModel);
        }
        public ActionResult Index()
        {
            return View();
        }
    
    }
}