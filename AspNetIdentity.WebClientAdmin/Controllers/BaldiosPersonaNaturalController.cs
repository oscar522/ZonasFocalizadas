using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Linq;
using System.Configuration;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class BaldiosPersonaNaturalController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> BuscaArchivos(int IdTable)  // --------------------- //

        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalBuscarArchivos";
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
                return Json("ok");
            }
        }
        public async Task<ActionResult>  ListDepto()
        {
            string Id = "0";
            string Controller = "hvctDepto";
            string Method = "gethvctDepto";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());
        }

        public async Task<ActionResult> ListDeptoId(string IdP)
        {
            string Controller = "hvctDepto";
            string Method = "gethvctdepto";
            string result = await employeeProvider.Get(IdP, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());

        }

        public async Task<ActionResult> ListPais()
        {
            string Id = "0";
            string Controller = "hvctpais";
            string Method = "gethvctpais";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtPaisModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> ListRetencionDocumentalGrupo()
        {
            string Id = "0";
            string Controller = "RetencionDocumentalGrupo";
            string Method = "getRetencionDocumentalGrupo";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RetencionDocumentalGrupoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RetencionDocumentalGrupoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NombreGrupo, Value = x.Id.ToString() }).ToList());
        }

        public async Task<ActionResult> ListRetencionDocumental(int Id)
        {
            string Controller = "RetencionDocumental";
            string Method = "getRetencionDocumentalGrupo";
            string result = await employeeProvider.Get(Id.ToString(), Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RetencionDocumentalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RetencionDocumentalModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() }).ToList());
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

        public async Task<JsonResult> ListExpedienteDocumentosByIdDoc(string Id)
        {   
            string Controller = "ExpedienteDocumentos";
            string Method = "getExpedienteDocumentosIdExpedienteIdDoc";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ExpedienteDocumentosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExpedienteDocumentosModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> PostExpedienteDocumentos(int EstadoExp , int EstadoExpUser,  int IdRetencionDocumental,int IdExpediente, int PagInicial, int PagFinal, string ArchivoActual, string ArchivoActualUrl)
        {
            // EstadoExp 
            // true = verificado
            // false = no verificado 

            ExpedienteDocumentosModel ObjData = new ExpedienteDocumentosModel();
            ObjData.Id = 0;
            ObjData.IdRetencionDocumental = IdRetencionDocumental;
            ObjData.NombreRetencionDocumental = "NA";
            ObjData.IdExpediente = IdExpediente;
            ObjData.NombreExpediente = "NA";
            ObjData.PagInicial = PagInicial;
            ObjData.PagFinal = PagFinal;
            ObjData.Archivo = ArchivoActual;
            ObjData.ArchivoUrl = ArchivoActualUrl;
            if (EstadoExpUser == 1) { ObjData.Estado = true; } else { ObjData.Estado = false; }
            ObjData.EstadoExp = EstadoExp;
            ObjData.FechaInserta = DateTime.Now.ToString();
            ObjData.FechaModifica = DateTime.Now.ToString();
            ObjData.UsuarioInserta = GetTokenObject().nameid;
            ObjData.UsuarioModifica = GetTokenObject().nameid;
            string Controller = "ExpedienteDocumentos";
            string Method = "ExpedienteDocumentoscreate";

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
                    if (processModel.UsuarioModifica.Equals(""))
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

        public async Task<JsonResult> PostUpdateStatus(int TypeMetodo, int Id, string ValueMe)
        {
            // EstadoExp 
            // true = verificado
            // false = no verificado 

            CtGeneroModel ObjData = new CtGeneroModel();
            ObjData.ID_GENERO = Id;
            ObjData.NOMBRE = ValueMe;
            string Controller = "BaldiosPersonaNatural";
            string Method = "";
            if (TypeMetodo == 1 )
            {
                Method = "BaldiosPersonaNaturalUpdateArchivoVerificado";
            }
            else {
                Method = "BaldiosPersonaNaturalUpdateEstatusCaracterizacion";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    CtGeneroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CtGeneroModel>(jsonResult.ToString());
                    if (processModel.NOMBRE.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        return Json("OK");
                    }
                }
                catch (InvalidCastException e)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator." + e);
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


        public async Task<JsonResult> DeleteExpedienteDocumentos(int IdDoc)
        {
            string processModel = "";
            try {
                string Id = IdDoc.ToString();
                string Controller = "ExpedienteDocumentos";
                string Method = "getExpedienteDocumentosdelete";
                string result = await employeeProvider.Delete(Controller, Method, Id);
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = jsonResult.ToString();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error reading from {0}. Message = {1}",  e.Message);
            }

            // string Controller, string Method, string Id
            return Json(new { Resultado = processModel }, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> Index()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNatural";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> IndexUser()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalUser";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> IndexUserMal()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalUserMal";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("IndexUser", processModel);
        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(BaldiosPersonaNaturalModel ObjData)
        {
            string Controller = "BaldiosPersonaNatural";
            string Method = "BaldiosPersonaNaturalcreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
                    if (processModel.NumeroExpediente.Equals(""))
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
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(BaldiosPersonaNaturalModel ObjData)
        {
            string Controller = "BaldiosPersonaNatural";
            string Method = "BaldiosPersonaNaturalupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
                    if (processModel.NumeroExpediente.Equals(""))
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
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(BaldiosPersonaNaturalModel ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturaldelete";
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