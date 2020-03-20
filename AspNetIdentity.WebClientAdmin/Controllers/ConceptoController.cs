using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Linq;
using System.IO;
using System.Web;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class ConceptoController : BaseController
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

        public async Task<ActionResult> ListCausas()
        {
            string Id = "0";
            string Controller = "Concepto";
            string Method = "getConceptoCausa";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());
        }

        public async Task<ActionResult> ListRolesUsuario(string Id)
        {
            string Controller = "Concepto";
            string Method = "getConceptoU";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.NOMBRE_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> ListUsuarionceptos(string Id)
        {
            string Controller = "Concepto";
            string Method = "getConceptoUC";
            List<ConceptoModel> processModel = new List<ConceptoModel>();
            if (!Id.Equals("0"))
            {
                string result = await employeeProvider.Get(Id, Controller, Method);
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConceptoModel>>(jsonResult.ToString());

            }
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteUsuarionceptos(string Id)
        {
            string Controller = "Concepto";
            string Method = "getConceptoUCD";
            string processModel = "";
            if (!Id.Equals("0"))
            {
                string result = await employeeProvider.Get(Id, Controller, Method);
                processModel = Newtonsoft.Json.JsonConvert.DeserializeObject(result).ToString();

            }
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ListRoles()
        {
            string Id = "0";
            string Controller = "Concepto";
            string Method = "getConceptoTU";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.NOMBRE_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> BuscarExpedientes(string key)
        {
            string Id = key;
            string Controller = "HomeUsuarios";
            string Method = "getBuscarExpediente";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "Concepto";
            string Method = "getConcepto";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ConceptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConceptoModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {

            ConceptoMvcModel user = new ConceptoMvcModel();
            //user.Id = 5;
            user.NombreAspNetUsers = GetTokenObject().FullName;
            user.IdAspNetUsers = GetTokenObject().nameid;
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(ConceptoMvcModel ObjData)
        {

            ConceptoModel ConceptoModel_ = new ConceptoModel();
            string Controller = "Concepto";
            string Method = "Conceptocreate";

            if (ModelState.IsValid)
            {
                try
                {
                    var ruta = Server.MapPath("~/Content/Pdfs/Conceptos");
                    DateTime fecha = DateTime.Now;
                    string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year;

                    if (ObjData.Soporte != null)
                    {
                        HttpPostedFileBase fileSoporte = ObjData.Soporte;
                        if (fileSoporte.ContentLength > 0)
                        {
                            string filename = string.Format("S_E_{0}_O_{1}_F_{2}.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            string filename2 = string.Format("S_E_{0}_O_{1}_F_{2}.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            filename = Path.Combine(ruta, filename);
                            fileSoporte.SaveAs(filename);
                            ConceptoModel_.Soporte = filename2;
                            ObjData.RutaSoporte = filename2;
                        }
                    }
                    else
                    {
                        ConceptoModel_.Soporte = "N/A";
                    }

                    if (ObjData.Anexo != null)
                    {
                        HttpPostedFileBase fileAnexo = ObjData.Anexo;
                        if (fileAnexo.ContentLength > 0)
                        {
                            string filename = string.Format("A_E_{0}_O_{1}_F_{2}.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            string filename2 = string.Format("A_E_{0}_O_{1}_F_{2}.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            filename = Path.Combine(ruta, filename);
                            fileAnexo.SaveAs(filename);
                            ConceptoModel_.Anexo = filename2;
                            ObjData.RutaAnexo = filename2;

                        }
                    }
                    else
                    {
                        ConceptoModel_.Anexo = "N/A";
                    }
                    ConceptoModel_.UserAsociado = ObjData.UserAsociado;
                    ConceptoModel_.IdCausa = ObjData.IdCausa;

                    if (ObjData.IdExpediente == null)
                    {
                        ConceptoModel_.IdExpediente = 0;
                    }
                    else
                    {
                        ConceptoModel_.IdExpediente = ObjData.IdExpediente;
                    }

                    if (ObjData.IdOrfeo == null)
                    {
                        ConceptoModel_.IdOrfeo = "N/A";
                    }
                    else
                    {
                        ConceptoModel_.IdOrfeo = ObjData.IdOrfeo;
                    }
                    ConceptoModel_.IdAspNetUsers = ObjData.IdAspNetUsers;
                    if (ObjData.Id <= 0)
                    {
                        ConceptoModel_.Id = 0;

                    }
                    else
                    {
                        ConceptoModel_.Id = ObjData.Id;
                    }
                    ConceptoModel_.RutaExpediente = ObjData.RutaExpediente;

                    ConceptoModel_.Rol = "N/A";
                    ConceptoModel_.NombreAspNetUsers = "N/A";
                    ConceptoModel_.NombreCausa = "N/A";
                    ConceptoModel_.Estado = true;
                    ConceptoModel_.FechaCreacion = DateTime.Now;

                    string Id = GetTokenObject().FullName;
                    ConceptoMvcModel user = new ConceptoMvcModel();
                    user.NombreAspNetUsers = Id;

                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ConceptoModel_);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ConceptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoModel>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        ObjData.Id = processModel.Id;
                        return View("Crear", ObjData);

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
            string Controller = "Concepto";
            string Method = "getConceptoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ConceptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoModel>(jsonResult.ToString());

            ConceptoMvcModel ConceptoMvcModel_ = new ConceptoMvcModel
            {

                Id = processModel.Id,
                IdAspNetUsers = processModel.IdAspNetUsers,
                UserAsociado = processModel.UserAsociado,
                Rol = processModel.Rol,
                NombreAspNetUsers = processModel.NombreAspNetUsers,
                IdCausa = processModel.IdCausa,
                NombreCausa = processModel.NombreCausa,
                IdExpediente = processModel.IdExpediente,
                RutaExpediente = processModel.RutaExpediente,
                RutaSoporte = processModel.Soporte,
                RutaAnexo = processModel.Anexo,
                IdOrfeo = processModel.IdOrfeo,
                Estado = processModel.Estado,
                FechaCreacion = processModel.FechaCreacion,

            };
            return View(ConceptoMvcModel_);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ConceptoMvcModel ObjData)
        {
            string Controller = "Concepto";
            ConceptoModel ConceptoModel_ = new ConceptoModel();
            string Method = "Conceptoupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    var ruta = Server.MapPath("~/Content/Pdfs/Conceptos");
                    DateTime fecha = DateTime.Now;
                    string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year;

                    if (ObjData.Soporte != null)
                    {
                        HttpPostedFileBase fileSoporte = ObjData.Soporte;
                        if (fileSoporte.ContentLength > 0)
                        {
                            string filename = string.Format("S_E_{0}_O_{1}_F_{2}_U.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            string filename2 = string.Format("S_E_{0}_O_{1}_F_{2}_U.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            filename = Path.Combine(ruta, filename);
                            fileSoporte.SaveAs(filename);
                            ConceptoModel_.Soporte = filename2;
                            ObjData.RutaSoporte = filename2;
                        }
                    }
                    else {
                        if (ObjData.RutaSoporte != "N/A")
                        {
                            ConceptoModel_.Soporte = ObjData.RutaSoporte;
                        }
                        else
                        {
                            ConceptoModel_.Soporte = "N/A";
                        }

                    }
                    if (ObjData.Anexo != null)
                    {
                        HttpPostedFileBase fileAnexo = ObjData.Anexo;
                        if (fileAnexo.ContentLength > 0)
                        {
                            string filename = string.Format("A_E_{0}_O_{1}_F_{2}_U.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            string filename2 = string.Format("A_E_{0}_O_{1}_F_{2}_U.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            filename = Path.Combine(ruta, filename);
                            fileAnexo.SaveAs(filename);
                            ConceptoModel_.Anexo = filename2;
                            ObjData.RutaAnexo = filename2;

                        }
                    }
                    else {
                        if (ConceptoModel_.Anexo != "N/A")
                        {
                            ConceptoModel_.Anexo = ObjData.RutaAnexo;
                        }
                        else
                        {
                            ConceptoModel_.Anexo = "N/A";
                        }
                    }

                    ConceptoModel_.UserAsociado = ObjData.UserAsociado;
                    ConceptoModel_.IdCausa = ObjData.IdCausa;

                    if (ObjData.IdExpediente == null)
                    {
                        ConceptoModel_.IdExpediente = 0;
                    }
                    else
                    {
                        ConceptoModel_.IdExpediente = ObjData.IdExpediente;
                    }

                    if (ObjData.IdOrfeo == null)
                    {
                        ConceptoModel_.IdOrfeo = "N/A";
                    }
                    else
                    {
                        ConceptoModel_.IdOrfeo = ObjData.IdOrfeo;
                    }
                    ConceptoModel_.IdAspNetUsers = ObjData.IdAspNetUsers;
                    if (ObjData.Id <= 0)
                    {
                        ConceptoModel_.Id = 0;

                    }
                    else
                    {
                        ConceptoModel_.Id = ObjData.Id;
                    }
                    ConceptoModel_.RutaExpediente = ObjData.RutaExpediente;

                    ConceptoModel_.Rol = "N/A";
                    ConceptoModel_.NombreAspNetUsers = "N/A";
                    ConceptoModel_.NombreCausa = "N/A";
                    ConceptoModel_.Estado = true;
                    ConceptoModel_.FechaCreacion = DateTime.Now;

                    string Id = GetTokenObject().FullName;
                    ConceptoMvcModel user = new ConceptoMvcModel();
                    user.NombreAspNetUsers = Id;
                    if (ObjData.UserAsociado == null)
                    {
                        ConceptoModel_.UserAsociado = "N/A";
                    }
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ConceptoModel_);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ConceptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoModel>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        ObjData.Id = processModel.Id;
                        return View("Edit", ObjData);
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
            string Controller = "Concepto";
            string Method = "getConceptoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ConceptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoModel>(jsonResult.ToString());

            ConceptoMvcModel ConceptoMvcModel_ = new ConceptoMvcModel
            {

                Id = processModel.Id,
                IdAspNetUsers = processModel.IdAspNetUsers,
                UserAsociado = processModel.UserAsociado,
                Rol = processModel.Rol,
                NombreAspNetUsers = processModel.NombreAspNetUsers,
                IdCausa = processModel.IdCausa,
                NombreCausa = processModel.NombreCausa,
                IdExpediente = processModel.IdExpediente,
                RutaExpediente = processModel.RutaExpediente,
                RutaSoporte = processModel.Soporte,
                RutaAnexo = processModel.Anexo,
                IdOrfeo = processModel.IdOrfeo,
                Estado = processModel.Estado,
                FechaCreacion = processModel.FechaCreacion,

            };
            return View(ConceptoMvcModel_);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Concepto";
            string Method = "getConceptoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ConceptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ConceptoModel ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "Concepto";
            string Method = "getConceptodelete";
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