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
    public class ExpedienteDocumentosController : BaseController
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
        
        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "hvExpedienteDocumentos";
            string Method = "gethvExpedienteDocumentos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ExpedienteDocumentosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExpedienteDocumentosModel>>(jsonResult.ToString());
            return View(processModel);

        }

        public async Task<ActionResult> ViewerPdf(int Id)
        {
            string Controller = "ExpedienteDocumentos";
            string Method = "getExpedienteDocumentos";
            string result = await employeeProvider.Get(Id.ToString(), Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ExpedienteDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpedienteDocumentosModel>(jsonResult.ToString());
            return View(processModel);

        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(ExpedienteDocumentosModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "hvExpedienteDocumentos";
            string Method = "hvExpedienteDocumentoscreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ExpedienteDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpedienteDocumentosModel>(jsonResult.ToString());
                    if (processModel.Id.ToString().Equals(""))
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
            string Controller = "hvExpedienteDocumentos";
            string Method = "gethvExpedienteDocumentosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ExpedienteDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpedienteDocumentosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(ExpedienteDocumentosModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "hvExpedienteDocumentos";
            string Method = "hvExpedienteDocumentosupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ExpedienteDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpedienteDocumentosModel>(jsonResult.ToString());
                    if (processModel.Id.ToString().Equals(""))
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

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvExpedienteDocumentos";
            string Method = "gethvExpedienteDocumentosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ExpedienteDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpedienteDocumentosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvExpedienteDocumentos";
            string Method = "gethvExpedienteDocumentosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ExpedienteDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpedienteDocumentosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(ExpedienteDocumentosModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvExpedienteDocumentos";
            string Method = "gethvExpedienteDocumentosdelete";
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