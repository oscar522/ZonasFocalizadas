﻿using AspNetIdentity.WebClientAdmin.Providers;
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

        #region Catalogos

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

        public  ActionResult DataLogin()
        {
            ConceptoMvcModel user = new ConceptoMvcModel();
            //user.Id = 5;
            user.NombreAspNetUsers = GetTokenObject().FullName;
            user.IdAspNetUsers = GetTokenObject().nameid;
            user.Rol = GetTokenObject().role;
            return Json(user, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region Conceptos

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
            user.Rol = GetTokenObject().role;
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
                    DateTime fecha = DateTime.Now;
                    string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year + "-" + fecha.Hour + "-" + fecha.Minute + "-" + fecha.Second + "-" + fecha.Millisecond;

                    if (ObjData.IdAspNetUsers != null) ConceptoModel_.IdAspNetUsers = ObjData.IdAspNetUsers; else ConceptoModel_.IdAspNetUsers = "N_A";

                    if (ObjData.UserAsociado != null) ConceptoModel_.UserAsociado = ObjData.UserAsociado; else ConceptoModel_.UserAsociado = "N_A";

                    if (ObjData.Rol != null) ConceptoModel_.Rol = ObjData.Rol; else ConceptoModel_.Rol = "N_A";

                    if (ObjData.NombreAspNetUsers != null) ConceptoModel_.NombreAspNetUsers = ObjData.NombreAspNetUsers; else ConceptoModel_.NombreAspNetUsers = "N_A";

                    if (ObjData.NombreCausa != null) ConceptoModel_.NombreCausa = ObjData.NombreCausa; else ConceptoModel_.NombreCausa = "N_A";

                    if (ObjData.RutaExpediente != null) ConceptoModel_.RutaExpediente = ObjData.RutaExpediente; else ConceptoModel_.NombreCausa = "N_A";

                    if (ObjData.RutaSoporte == null) ObjData.RutaSoporte = "N_A";

                    if (ObjData.RutaAnexo == null) ObjData.RutaAnexo = "N_A";

                    if (ObjData.IdOrfeo != null) ConceptoModel_.IdOrfeo = ObjData.IdOrfeo; else ConceptoModel_.IdOrfeo = "N_A";
                    if (ObjData.NombrePredio != null) ConceptoModel_.NombrePredio = ObjData.NombrePredio; else ConceptoModel_.NombrePredio = "N_A";

                    if (ObjData.Observacion == null) ObjData.Observacion = "N_A";

                    ConceptoModel_.Id = ObjData.Id;
                    ConceptoModel_.FechaCreacion = fecha;
                    ConceptoModel_.IdCausa = ObjData.IdCausa;
                    ConceptoModel_.Soporte = "N_A";
                    ConceptoModel_.IdExpediente = 0;
                    ConceptoModel_.Estado = true;
                    ConceptoModel_.IdExpediente = 0;
                    ConceptoModel_.Anexo = "N_A";
                    ConceptoModel_.TerminoDias = ObjData.TerminoDias.Value;
                    ConceptoModel_.Observacion = ObjData.Observacion;
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
                        ObjData.NombreCausa = "Ok";
                        ObjData.Id = processModel.Id;
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

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Concepto";
            string Method = "getConceptoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            ConceptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoModel>(jsonResult.ToString());
            var usuarioLogin = GetTokenObject();
            processModel.UserAsociado = usuarioLogin.nameid;


            ConceptoMvcModel ConceptoMvcModel_ = new ConceptoMvcModel
            {

                Id = processModel.Id,
                IdAspNetUsers = processModel.IdAspNetUsers+"|"+ usuarioLogin.nameid,
                UserAsociado = processModel.UserAsociado,
                Rol = processModel.Rol,
                NombreAspNetUsers = processModel.NombreAspNetUsers,
                IdCausa = processModel.IdCausa,
                NombreCausa = usuarioLogin.role,
                IdExpediente = processModel.IdExpediente,
                RutaExpediente = processModel.RutaExpediente,
                RutaSoporte = processModel.Soporte,
                RutaAnexo = processModel.Anexo,
                IdOrfeo = processModel.IdOrfeo,
                Estado = processModel.Estado,
                FechaCreacion = processModel.FechaCreacion,
                NombrePredio = processModel.NombrePredio,
                TerminoDias = processModel.TerminoDias,
                Observacion = processModel.Observacion



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
                TerminoDias = processModel.TerminoDias,
                Observacion = processModel.Observacion

            };
            return View(ConceptoMvcModel_);
        }

        public async Task<ActionResult> Delete(int IdTable)
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

        #endregion

        #region soportes
        public async Task<ActionResult> CrearSoportes(ConceptoMvcModel ObjData)
        {
            ConceptoModel ConceptoModel_ = new ConceptoModel();
            DateTime fecha = DateTime.Now;
            string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year + "-" + fecha.Hour + "-" + fecha.Minute + "-" + fecha.Second + "-" + fecha.Millisecond;
            var ruta = Server.MapPath("~/Content/Pdfs/Conceptos");

            if (ObjData.IdAspNetUsers != null) ConceptoModel_.IdAspNetUsers = ObjData.IdAspNetUsers; else ConceptoModel_.IdAspNetUsers = "N_A";

            if (ObjData.UserAsociado != null) ConceptoModel_.UserAsociado = ObjData.UserAsociado; else ConceptoModel_.UserAsociado = "N_A";

            if (ObjData.Rol != null) ConceptoModel_.Rol = ObjData.Rol; else ConceptoModel_.Rol = "N_A";

            if (ObjData.NombreAspNetUsers != null) ConceptoModel_.NombreAspNetUsers = ObjData.NombreAspNetUsers; else ConceptoModel_.NombreAspNetUsers = "N_A";

            if (ObjData.NombreCausa != null) ConceptoModel_.NombreCausa = ObjData.NombreCausa; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaExpediente != null) ConceptoModel_.RutaExpediente = ObjData.RutaExpediente; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaSoporte == null) ObjData.RutaSoporte = "N_A"; 

            if (ObjData.RutaAnexo == null) ObjData.RutaAnexo = "N_A"; 

            if (ObjData.IdOrfeo != null) ConceptoModel_.IdOrfeo = ObjData.IdOrfeo; else ConceptoModel_.IdOrfeo = "N_A";

            if (ObjData.Observacion == null) ObjData.Observacion = "N_A";

            ConceptoModel_.Id = ObjData.Id;
            ConceptoModel_.TerminoDias = 0;
            ConceptoModel_.Observacion = "N_A";
            ConceptoModel_.IdExpediente = 0;
            ConceptoModel_.NombrePredio = "N_A";
            ConceptoModel_.IdCausa =  0;
            ConceptoModel_.FechaCreacion =fecha;

            ConceptoModel_.Anexo =  "N_A"; 
            ConceptoModel_.Estado = true;

            string Controller = "Concepto";
            string Method = "ConceptoCrearDocumentoSoporte";
            if (ModelState.IsValid)
            {
                try
                {
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
                        return Json(processModel, JsonRequestBehavior.AllowGet);

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

        public async Task<ActionResult> ConsultaDocumentoSoporte(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoConsultaDocumentoSoporte";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtPaisModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteDocumentoSoporte(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoDeleteDocumentoSoporte";
            string result = await employeeProvider.Delete(Controller, Method,  Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Anexo
        public async Task<ActionResult> CrearAnexo(ConceptoMvcModel ObjData)
        {
            ConceptoModel ConceptoModel_ = new ConceptoModel();
            DateTime fecha = DateTime.Now;
            string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year + "-" + fecha.Hour + "-" + fecha.Minute + "-" + fecha.Second + "-" + fecha.Millisecond;
            var ruta = Server.MapPath("~/Content/Pdfs/Conceptos");

            if (ObjData.IdAspNetUsers != null) ConceptoModel_.IdAspNetUsers = ObjData.IdAspNetUsers; else ConceptoModel_.IdAspNetUsers = "N_A";

            if (ObjData.UserAsociado != null) ConceptoModel_.UserAsociado = ObjData.UserAsociado; else ConceptoModel_.UserAsociado = "N_A";

            if (ObjData.Rol != null) ConceptoModel_.Rol = ObjData.Rol; else ConceptoModel_.Rol = "N_A";

            if (ObjData.NombreAspNetUsers != null) ConceptoModel_.NombreAspNetUsers = ObjData.NombreAspNetUsers; else ConceptoModel_.NombreAspNetUsers = "N_A";

            if (ObjData.NombreCausa != null) ConceptoModel_.NombreCausa = ObjData.NombreCausa; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaExpediente != null) ConceptoModel_.RutaExpediente = ObjData.RutaExpediente; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaSoporte == null) ObjData.RutaSoporte = "N_A";

            if (ObjData.RutaAnexo == null) ObjData.RutaAnexo = "N_A";

            if (ObjData.IdOrfeo != null) ConceptoModel_.IdOrfeo = ObjData.IdOrfeo; else ConceptoModel_.IdOrfeo = "N_A";

            if (ObjData.Observacion == null) ObjData.Observacion = "N_A";

            ConceptoModel_.Id = ObjData.Id;
            ConceptoModel_.IdCausa = 0;
            ConceptoModel_.IdExpediente = 0;
            ConceptoModel_.TerminoDias =0;
            ConceptoModel_.Observacion = "N_A";
            ConceptoModel_.FechaCreacion = fecha;
            ConceptoModel_.Soporte = "N_A";
            ConceptoModel_.NombrePredio = "N_A";
            ConceptoModel_.Estado = true;

            string Controller = "Concepto";
            string Method = "ConceptoCrearDocumentoAnexo";
            if (ModelState.IsValid)
            {
                try
                {
                    if (ObjData.Anexo != null)
                    {
                        HttpPostedFileBase fileSoporte = ObjData.Anexo;
                        if (fileSoporte.ContentLength > 0)
                        {
                            string filename = string.Format("A_E_{0}_O_{1}_F_{2}.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            string filename2 = string.Format("A_E_{0}_O_{1}_F_{2}.pdf", ObjData.IdExpediente, ObjData.IdOrfeo, FechaFor);
                            filename = Path.Combine(ruta, filename);
                            fileSoporte.SaveAs(filename);
                            ConceptoModel_.Anexo = filename2;
                            ObjData.RutaAnexo = filename2;
                        }
                    }
                    else
                    {
                        ConceptoModel_.Anexo = "N/A";
                    }

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
                        return Json(processModel, JsonRequestBehavior.AllowGet);

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

        public async Task<ActionResult> ConsultaDocumentoAnexo(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoConsultaDocumentoAnexo";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtPaisModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteDocumentoAnexo(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoDeleteDocumentoAnexo";
            string result = await employeeProvider.Delete(Controller, Method, Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Expedientes
        public async Task<ActionResult> CrearExpedientes(ConceptoMvcModel ObjData)
        {
            DateTime fecha = DateTime.Now;
            string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year + "-" + fecha.Hour + "-" + fecha.Minute + "-" + fecha.Second + "-" + fecha.Millisecond;

            ConceptoModel ConceptoModel_ = new ConceptoModel();

            if (ObjData.IdAspNetUsers != null) ConceptoModel_.IdAspNetUsers = ObjData.IdAspNetUsers; else ConceptoModel_.IdAspNetUsers = "N_A";

            if (ObjData.UserAsociado != null) ConceptoModel_.UserAsociado = ObjData.UserAsociado; else ConceptoModel_.UserAsociado = "N_A";

            if (ObjData.Rol != null) ConceptoModel_.Rol = ObjData.Rol; else ConceptoModel_.Rol = "N_A";

            if (ObjData.NombreAspNetUsers != null) ConceptoModel_.NombreAspNetUsers = ObjData.NombreAspNetUsers; else ConceptoModel_.NombreAspNetUsers = "N_A";

            if (ObjData.NombreCausa != null) ConceptoModel_.NombreCausa = ObjData.NombreCausa; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaExpediente != null) ConceptoModel_.RutaExpediente = ObjData.RutaExpediente; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaSoporte == null) ObjData.RutaSoporte = "N_A";

            if (ObjData.RutaAnexo == null) ObjData.RutaAnexo = "N_A";

            if (ObjData.IdOrfeo != null) ConceptoModel_.IdOrfeo = ObjData.IdOrfeo; else ConceptoModel_.IdOrfeo = "N_A";

            if (ObjData.Observacion == null) ObjData.Observacion = "N_A";

            ConceptoModel_.Id = ObjData.Id;
            ConceptoModel_.FechaCreacion = fecha;
            ConceptoModel_.IdCausa = 0;
            ConceptoModel_.TerminoDias = 0;
            ConceptoModel_.Observacion = "N_A";
            ConceptoModel_.Soporte = "N_A";
            ConceptoModel_.Estado = true;
            ConceptoModel_.NombrePredio = "N_A";
            ConceptoModel_.IdExpediente = ObjData.IdExpediente;

            string Controller = "Concepto";
            string Method = "ConceptoCrearExpediente";
            if (ModelState.IsValid)
            {
                try
                {
                    ObjData.RutaAnexo = "N/A";
                    ConceptoModel_.Anexo = "N/A";

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
                        return Json(processModel, JsonRequestBehavior.AllowGet);

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

        public async Task<ActionResult> ConsultaExpediente(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoConsultaExpediente";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ConsultaExpedientesAsociados(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoConsultaExpedientesAsociados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtPaisModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteExpediente(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoDeleteExpediente";
            string result = await employeeProvider.Delete(Controller, Method, Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region UsuariosAsociados

        public ConceptoModel DtoConceptoModel(ConceptoMvcModel ObjData) {

            DateTime fecha = DateTime.Now;

            ConceptoModel ConceptoModel_ = new ConceptoModel();

            if (ObjData.IdAspNetUsers != null) ConceptoModel_.IdAspNetUsers = ObjData.IdAspNetUsers; else ConceptoModel_.IdAspNetUsers = "N_A";

            if (ObjData.UserAsociado != null) ConceptoModel_.UserAsociado = ObjData.UserAsociado; else ConceptoModel_.UserAsociado = "N_A";

            if (ObjData.Rol != null) ConceptoModel_.Rol = ObjData.Rol; else ConceptoModel_.Rol = "N_A";

            if (ObjData.NombreAspNetUsers != null) ConceptoModel_.NombreAspNetUsers = ObjData.NombreAspNetUsers; else ConceptoModel_.NombreAspNetUsers = "N_A";

            if (ObjData.NombreCausa != null) ConceptoModel_.NombreCausa = ObjData.NombreCausa; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaExpediente != null) ConceptoModel_.RutaExpediente = ObjData.RutaExpediente; else ConceptoModel_.NombreCausa = "N_A";

            if (ObjData.RutaSoporte == null) ObjData.RutaSoporte = "N_A";

            if (ObjData.RutaAnexo == null) ObjData.RutaAnexo = "N_A";

            if (ObjData.IdOrfeo != null) ConceptoModel_.IdOrfeo = ObjData.IdOrfeo; else ConceptoModel_.IdOrfeo = "N_A";

            if (ObjData.Observacion == null) ObjData.Observacion = "N_A";

            ConceptoModel_.Id = ObjData.Id;
            ConceptoModel_.FechaCreacion = fecha;
            ConceptoModel_.IdCausa =0;
            ConceptoModel_.TerminoDias = 0;
            ConceptoModel_.Observacion = "N_A";
            ConceptoModel_.Soporte = "N_A";
            ConceptoModel_.Estado = true;
            ConceptoModel_.IdExpediente = 0;
            ConceptoModel_.Anexo = "N/A";
            ConceptoModel_.NombrePredio = "N_A";

            return ConceptoModel_;
        }
        public async Task<ActionResult> CrearUsuariosAsociados(ConceptoMvcModel ObjData)
        {
            ConceptoModel ConceptoModel_ = DtoConceptoModel(ObjData);

            string Controller = "Concepto";
            string Method = "ConceptoCrearUsuariosAsociados";
            if (ModelState.IsValid)
            {
                try
                {

                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ConceptoModel_);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ConceptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoModel>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
                    {
                        return Json("error 1");
                    }
                    else
                    {
                        ObjData.Id = processModel.Id;
                        return Json(processModel, JsonRequestBehavior.AllowGet);

                    }
                }
                catch
                {
                    return Json("error2");

                    //return Json(ModelState);
                }
            }
            else
            {
                return Json("error 3");
            }
        }

        public async Task<ActionResult> ConsultaUsuariosAsociados(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoConsultaUsuariosAsociados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ConceptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConceptoModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }
        
        public async Task<ActionResult> DeleteUsuariosAsociados(string key)
        {
            string Id = key;
            string Controller = "Concepto";
            string Method = "getConceptoDeleteUsuariosAsociados";
            string result = await employeeProvider.Delete(Controller, Method, Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Gestiones

        public async Task<ActionResult> ListGestionEstado()
        {
            string Id = "0";
            string Controller = "ConceptoGestion";
            string Method = "getConsultaEstados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ConceptoEstadoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConceptoEstadoModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> ListGestionSoporte()
        {
            string Id = "0";
            string Controller = "ConceptoGestion";
            string Method = "getConceptoTipoSoporte";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ConceptoTipoSoporteModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConceptoTipoSoporteModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> CrearGestion(ConceptoGestionViewModels ObjData)
        {
            var ruta = Server.MapPath("~/Content/Pdfs/Conceptos/Gestion");
            DateTime fecha = DateTime.Now;
            string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year + "-" + fecha.Hour + "-" + fecha.Minute + "-" + fecha.Second + "-" + fecha.Millisecond;

            ObjData.Estado = true;
            ObjData.FCreacion = DateTime.Now;
            
            ConceptoGestionModel ConceptoGestionModel = new ConceptoGestionModel();
            
            string Controller = "ConceptoGestion";
            string Method = "ConceptosGestioncreate";

            if (ModelState.IsValid)
            {
                try
                {

                    if (ObjData.Archivo != null)
                    {
                        HttpPostedFileBase fileSoporte = ObjData.Archivo;
                        var ext = Path.GetExtension(ObjData.Archivo.FileName);

                        if (fileSoporte.ContentLength > 0)
                        {
                            string filename = string.Format("{0}_C_{1}_F_{2}{3}", ObjData.NombreIdSoporte, ObjData.IdConcepto, FechaFor, ext);
                            ConceptoGestionModel.Archivo = filename;

                            filename = Path.Combine(ruta, filename);
                            fileSoporte.SaveAs(filename);
                        }
                        
                    }
                    else
                    {
                        ConceptoGestionModel.Archivo = "N_A";
                    }

                    ConceptoGestionModel.Id = 0;
                    ConceptoGestionModel.Id = ObjData.Id;
                    ConceptoGestionModel.IdConcepto = ObjData.IdConcepto;
                    ConceptoGestionModel.IdEstado = ObjData.IdEstado;
                    ConceptoGestionModel.IdSoporte = ObjData.IdSoporte;
                    ConceptoGestionModel.Observacion = ObjData.GestionObservacion;
                    ConceptoGestionModel.FCreacion = ObjData.FCreacion.ToString();
                    ConceptoGestionModel.Estado = ObjData.Estado;
                    ConceptoGestionModel.NombreIdSoporte = ObjData.NombreIdSoporte;
                    ConceptoGestionModel.NombreIdEstado = ObjData.NombreIdEstado;
                    ConceptoGestionModel.IdAspNetUserGestion = ObjData.IdAspNetUserGestion;
                    ConceptoGestionModel.IdRolUser = "N_A";
                    ConceptoGestionModel.RolUser = "N_A";
                    ConceptoGestionModel.NombreUser = "N_A";
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ConceptoGestionModel);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ConceptoGestionModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ConceptoGestionModel>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        ObjData.NombreIdEstado = "Ok";
                        ObjData.Id = processModel.Id;
                        return Json(ObjData.NombreIdEstado, JsonRequestBehavior.AllowGet);
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
                        return Json(ModelState);

            }
        }

        public async Task<ActionResult> ListGestion(string Id)
        {
            string Controller = "ConceptoGestion";
            string Method = "getConceptosGestionIdConcepto";
            List<ConceptoGestionModel> processModel = new List<ConceptoGestionModel>();
            if (!Id.Equals("0"))
            {
                string result = await employeeProvider.Get(Id, Controller, Method);
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConceptoGestionModel>>(jsonResult.ToString());

            }
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}