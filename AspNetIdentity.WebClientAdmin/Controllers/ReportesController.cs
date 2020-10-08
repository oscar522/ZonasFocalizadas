using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Linq;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    //[Authorize]
    public class ReportesController : WebClientAdmin.BaseController
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

        public async Task<ActionResult>Registro()
        {
            string Id = "0";
            string Controller = "Reportes";
            string Method = "getRegistro";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            string processModel = jsonResult.ToString();
            return new JsonResult()
            {
                Data = processModel,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> Juridica()
        {
            string Id = "0";
            string Controller = "Reportes";
            string Method = "getJuridica";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            string processModel = jsonResult.ToString();
            return new JsonResult()
            {
                Data = processModel,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> Solicitante()
        {
            string Id = "0";
            string Controller = "Reportes";
            string Method = "getSolicitante";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            string processModel = jsonResult.ToString();
            return new JsonResult()
            {
                Data = processModel,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<ActionResult> Index()
        {
           
            return View();
        }

        
    }
}