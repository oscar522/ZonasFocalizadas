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
            string Method = "getRegistroid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RegistroModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegistroModel>>(jsonResult.ToString());
            return View(processModel);

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
            string Method = "getRegistroidExp";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            RegistroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistroModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(RegistroModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "Registro";
            string Method = "Registroupdate";

            if (ObjData.FVerificacion == null) { ObjData.FVerificacion = ""; }
            if (ObjData.Estado == null) { ObjData.Estado = false; }
            if (ObjData.Matricula == null) { ObjData.Matricula = ""; }
            if (ObjData.Fapertura == null) { ObjData.Fapertura = ""; }
            if (ObjData.TipoDocumento == null) { ObjData.TipoDocumento = ""; }
            if (ObjData.NumDocumento == null) { ObjData.NumDocumento = 0; }
            if (ObjData.FDocumento == null) { ObjData.FDocumento = ""; }
            if (ObjData.IdDepto == null) { ObjData.IdDepto = 0; }
            if (ObjData.IdMunicipio == null) { ObjData.IdMunicipio = 0; }
            if (ObjData.Area == null) { ObjData.Area = 0; }
            if (ObjData.CcSolicitante == null) { ObjData.CcSolicitante = 0; }
            if (ObjData.CcConyugue == null) { ObjData.CcConyugue = 0; }
            if (ObjData.Conyuge == null) { ObjData.Conyuge = ""; }
            if (ObjData.EstadoRegistro == null) { ObjData.EstadoRegistro = false; }
            if (ObjData.UsuarioModifica == null) { ObjData.UsuarioModifica = ""; }
            if (ObjData.UsuarioActualiza == null) { ObjData.UsuarioActualiza = ""; }
            if (ObjData.NombreIdDepto == null) { ObjData.NombreIdDepto = ""; }
            if (ObjData.NombreIdMunicipio == null) { ObjData.NombreIdMunicipio = ""; }

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    RegistroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistroModel>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(ModelState);
                    }
                    else
                    {
                        return RedirectToAction("Index");

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
            string Controller = "Registro";
            string Method = "getRegistroid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            RegistroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistroModel>(jsonResult.ToString());
            return PartialView(processModel);
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