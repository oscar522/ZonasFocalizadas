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
    public class HomeAdministratorController : BaseController
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

        public async Task<ActionResult> CountDeptos()
        {
            string Id = "0";
            string Controller = "Administrator";
            string Method = "getAdministratorCountDeptos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtCiudadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtCiudadModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Resumen(int IdDepto, int IdCiudad)
        {
            string Id = IdDepto+"_"+IdCiudad+"_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "getResumen";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ResumenTipificacionModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenTipificacionModel>>(jsonResult.ToString());

            var Resumen = processModel
                          .GroupBy(z => z.Grupo)
                          .Select(c => new ResumenTipificacionVistaModel
                          {
                              Total = c.Count(),
                              Grupo = c.Select(v => v.Grupo).FirstOrDefault(),
                              Plano = processModel.Where(x => x.Plano == 21 && x.Grupo == c.Select(v => v.Grupo).FirstOrDefault()).Count(),
                              Orden = c.Select(v => v.Orden).FirstOrDefault(),
                          }).ToList();

            return View("ResumenIndex", Resumen);
        }

        public async Task<ActionResult> ResumenRegistro(int IdDepto, int IdCiudad)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "getResumenRegistro";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ResumenTipificacionModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenTipificacionModel>>(jsonResult.ToString());

            var Resumen = processModel
                          .GroupBy(z => z.Grupo)
                          .Select(c => new ResumenTipificacionVistaModel
                          {
                              Total = c.Count(),
                              Grupo = c.Select(v => v.Grupo).FirstOrDefault(),
                              Plano = processModel.Where(x => x.Plano == 21 && x.Grupo == c.Select(v => v.Grupo).FirstOrDefault()).Count(),
                              Orden = c.Select(v => v.Orden).FirstOrDefault(),
                              
                          }).ToList();

            return Json(Resumen, JsonRequestBehavior.AllowGet);
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

        public ActionResult ResumenIndex(int IdDeptoIn, int IdCiudadIn)
        {
            return Json(new { result = "Redirect", url = Url.Action("Resumen", "HomeAdministrator", new { IdDepto = IdDeptoIn, IdCiudad = IdCiudadIn }) });
        }
        public ActionResult Index()
        {
            return View();

        }
    
    }
}