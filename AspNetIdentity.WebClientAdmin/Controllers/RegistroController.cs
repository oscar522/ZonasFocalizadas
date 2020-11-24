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
    [Authorize]
    public class RegistroController : BaseController
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

        public async Task<ActionResult> ListDepto()
        {
            string Id = "0";
            string Controller = "hvctdepto";
            string Method = "gethvctdepto";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());
        }
        
        public async Task<ActionResult> ListCiudadId(string IdP)
        {
            string Id = IdP.ToString();
            string Controller = "hvctciudad";
            string Method = "gethvctciudad";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtCiudadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtCiudadModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCtMuncipio.ToString() }).ToList());
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

        public async Task<JsonResult> ExpedienteInfo(int Id)
        {
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id.ToString(), Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Index()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "Registro";
            string Method = "getRegistroidUser";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RegistroModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegistroModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> IndexRevisados()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "Registro";
            string Method = "getRegistroidRevisados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RegistroModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegistroModel>>(jsonResult.ToString());
            return View("Index",processModel);
        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(RegistroModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "Registro";
            string Method = "Registrocreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    RegistroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistroModel>(jsonResult.ToString());
                    if (processModel.Matricula.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        return Json("OK");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return Json(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                var errorList = (from item in ModelState
                                 from error in item.Value.Errors
                                 select new
                                 {
                                     Msg = error.ErrorMessage,
                                     Cam = item.Key
                                 }
                    ).ToList();
                return Json(errorList);
            }
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Registro";
            string Method = "getRegistroid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            RegistroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistroModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RegistroModel ObjData)
        {
            string Controller = "Registro";
            string Method = "Registroupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    CaracterizacionJuridicaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionJuridicaModel>(jsonResult.ToString());
                    if (processModel.Id == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(ObjData);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch(Exception e )
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator. "+
                        e.Message + " | "+ e.StackTrace + " | " + e.Source + " | " + e.InnerException + " | " + e.TargetSite + " | " + e.HelpLink + " | " + e.Data + " | " + e.HResult);
                    return View(ObjData);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Todos los campos requeridos ");
                return View(ObjData);
            }

        }

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Registro";
            string Method = "getRegistroidExp";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            RegistroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistroModel>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Registro";
            string Method = "getRegistroid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            RegistroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistroModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(RegistroModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Registro";
            string Method = "getRegistrodelete";
           string result = await employeeProvider.Delete(Controller, Method, Id); // ----------- //
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            var processModel = (jsonResult.ToString());
            if (processModel.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return Json(ModelState);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}