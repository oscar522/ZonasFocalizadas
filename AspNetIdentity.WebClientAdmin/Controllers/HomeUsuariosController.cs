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
    public class HomeUsuariosController : BaseController
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
            string Controller = "HomeUsuarios";
            string Method = "getCountRegistroAsociados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            int processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(jsonResult.ToString());
            return Json(processModel);
        }

        public  ActionResult BuscarExpedientes()
        {
            return View();
        }
        public async Task<ActionResult> BuscarExpedienteRun(string key)
        {
            string Id = key;
            string Controller = "HomeUsuarios";
            string Method = "getBuscarExpediente";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResultadoBusqueda", processModel);
        }

        public async Task<ActionResult> CountRevisados()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "HomeUsuarios";
            string Method = "getCountRegistroAsociadosRevisados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            int processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(jsonResult.ToString());
            return Json(processModel);
        }
       
        public ActionResult IndexRegistro()
        {
            return View("IndexRegistro");
        }
        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<JsonResult> ListExpedienteDocumentos(int Id)
        {
            string Controller = "ExpedienteDocumentos";
            string Method = "getExpedienteDocumentosIdExpediente";
            string result = await employeeProvider.Get(Id.ToString(), Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ExpedienteDocumentosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExpedienteDocumentosModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> ConsultaRegistro(long Id)
        {
            string Controller = "HomeUsuarios";
            string Method = "getRegistroIdExpediente";
            string result = await employeeProvider.Get(Id.ToString(), Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RegistroModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegistroModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

    }
}