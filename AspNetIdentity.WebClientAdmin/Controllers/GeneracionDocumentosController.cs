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
    public class GeneracionDocumentosController : BaseController
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

        //public async Task<ActionResult> ListTipos(string Id)
        //{
        //    string Controller = "GeneracionDocumentos";
        //    string Method = "getGeneracionDocumentosCatalogoid";
        //    string result = await employeeProvider.Get(Id, Controller, Method);
        //    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //    List<GeneracionDocumentosCatalogosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GeneracionDocumentosCatalogosModel>>(jsonResult.ToString());
        //    return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() }).ToList());
        //}

        public async Task<ActionResult> Index()
        {

            string Id = GetTokenObject().nameid;
            string Controller = "GeneracionDocumentos";
            string Method = "getGeneracionDocumentos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View(processModel);

        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(GeneracionDocumentosModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "GeneracionDocumentos";
            string Method = "GeneracionDocumentoscreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    GeneracionDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GeneracionDocumentosModel>(jsonResult.ToString());
                    if (processModel.Id == 0)
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
                    ModelState.AddModelError(string.Empty, "* Todos los campos son obligatorios.");
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
            string Controller = "GeneracionDocumentos";
            string Method = "getGeneracionDocumentosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            GeneracionDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GeneracionDocumentosModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(GeneracionDocumentosModel ObjData)
        {
            ObjData.Estado = true;
            string Id = GetTokenObject().nameid;
             string Controller = "GeneracionDocumentos";
            string Method = "GeneracionDocumentosupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    GeneracionDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GeneracionDocumentosModel>(jsonResult.ToString());
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
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
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
            string Controller = "GeneracionDocumentos";
            string Method = "getGeneracionDocumentosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            GeneracionDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GeneracionDocumentosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "GeneracionDocumentos";
            string Method = "getGeneracionDocumentosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            GeneracionDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GeneracionDocumentosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(GeneracionDocumentosModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "GeneracionDocumentos";
            string Method = "getGeneracionDocumentosdelete";
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