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
    public class ActividadesDiariasController : BaseController
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

        public async Task<ActionResult> RolList()
        {
            string Id = "0";
            string Controller = "ActividadesDiarias";
            string Method = "getRol";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.NOMBRE_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> TipoActividadList(string RolId)
        {
            string Controller = "TipoActividad";
            string Method = "getTipoActividadIdRol";
            string result = await employeeProvider.Get(RolId, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<TipoActividadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TipoActividadModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Actividad, Value = x.Id.ToString() }).ToList());
        }
        public async Task<ActionResult> ProcesoList()
        {
            string Id = "0";
            string Controller = "ActividadesDiarias";
            string Method = "getProceso";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtPaisModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> ModalidadList()
        {
            string Id = "0";
            string Controller = "ActividadesDiarias";
            string Method = "getModalidad";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtPaisModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> ListGeneral(string Id = "1")
        {
            PaginadorCustomersModel processModel = new PaginadorCustomersModel();
            if (Id != "")
            {
                string Controller = "ActividadesDiarias";
                string Method = "getActividadesDiarias";
                string result = await employeeProvider.Get(Id, Controller, Method);
                
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PaginadorCustomersModel>(jsonResult.ToString());
            }
            
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ListUser(string Id)
        {
            string Controller = "ActividadesDiarias";
            string Method = "getActividadesDiariasId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ActividadesDiariasModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ActividadesDiariasModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteActivity(string Id)
        {
            string Controller = "ActividadesDiarias";
            string Method = "getActividadesDiariasdelete";
            string result = await employeeProvider.Delete(Controller, Method, Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "ActividadesDiarias";
            string Method = "getActividadesDiarias";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ActividadesDiariasModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ActividadesDiariasModel>>(jsonResult.ToString());
            return View(processModel);

        }

        public ActionResult Crear()
        {
            ActividadesDiariasModel ActividadesDiariasModel_ = new ActividadesDiariasModel();
            ActividadesDiariasModel_.NombreUsuario = GetTokenObject().FullName;
            ActividadesDiariasModel_.IdApsNetUser = GetTokenObject().nameid;
            ActividadesDiariasModel_.RolUsuario = GetTokenObject().role;

            return View(ActividadesDiariasModel_);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(ActividadesDiariasModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "ActividadesDiarias";
            string Method = "ActividadesDiariascreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ActividadesDiariasModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ActividadesDiariasModel>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        return View(processModel);
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
            string Controller = "ActividadesDiarias";
            string Method = "getActividadesDiariasid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ActividadesDiariasModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ActividadesDiariasModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(ActividadesDiariasModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "ActividadesDiarias";
            string Method = "ActividadesDiariasupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ActividadesDiariasModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ActividadesDiariasModel>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
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
            string Controller = "ActividadesDiarias";
            string Method = "getActividadesDiariasid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ActividadesDiariasModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ActividadesDiariasModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "ActividadesDiarias";
            string Method = "getActividadesDiariasid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ActividadesDiariasModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ActividadesDiariasModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(ActividadesDiariasModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "ActividadesDiarias";
            string Method = "getActividadesDiariasdelete";
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