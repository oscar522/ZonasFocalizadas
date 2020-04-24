﻿using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.IO;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class CaracterizacionSolicitanteController : BaseController
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

        public async Task<ActionResult> TipoDoc()
        {
            string Controller = "hvcttipoidentificacion";
            string Method = "gethvcttipoidentificacion";
            string result = await employeeProvider.Get("0", Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtTipoIdentificacionModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtTipoIdentificacionModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_TIPO_IDENTIFICACION.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "CaracterizacionSolicitante";
            string Method = "getCaracterizacionSolicitanteidUser";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionSolicitanteModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionSolicitanteModel>>(jsonResult.ToString());
            return View(processModel);

        }



        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(CaracterizacionSolicitanteModel ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "CaracterizacionSolicitante";
            string Method = "CaracterizacionSolicitantecreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    CaracterizacionSolicitanteModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionSolicitanteModel>(jsonResult.ToString());
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

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CaracterizacionSolicitante";
            string Method = "getCaracterizacionSolicitanteid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            CaracterizacionSolicitanteModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionSolicitanteModel>(jsonResult.ToString());
            CaracterizacionSolicitanteViewModels Entity = new CaracterizacionSolicitanteViewModels {
                Id = processModel.Id,
                IdExpediente = processModel.IdExpediente,
                NombreSolicitanteExpediente = processModel.NombreSolicitanteExpediente,
                DocSolicitanteExpediente = processModel.DocSolicitanteExpediente,
                IdTipoDocSolicitanteExpediente = processModel.IdTipoDocSolicitanteExpediente,
                TipoDocSolicitanteExpediente = processModel.TipoDocSolicitanteExpediente,

                NombreConyugeExpediente = processModel.NombreConyugeExpediente,
                DocConyugeExpediente = processModel.DocConyugeExpediente,
                IdTipoDocConyugeExpediente = processModel.IdTipoDocConyugeExpediente,
                TipoDocConyugeExpediente = processModel.TipoDocConyugeExpediente,

                NumeroExpediente = processModel.NumeroExpediente,
                NombreSolicitante = processModel.NombreSolicitante,
                TipoDocumento = processModel.TipoDocumento,
                NombreTipoDocumento = processModel.NombreTipoDocumento,
                NumeroIdentificacion = processModel.NumeroIdentificacion,
                NombreConyuge = processModel.NombreConyuge,
                TipoDocumentoConyuge = processModel.TipoDocumentoConyuge,
                NombreTipoDocumentoConyuge = processModel.NombreTipoDocumentoConyuge,
                NumeroIdentificacionConyuge = processModel.NumeroIdentificacionConyuge,

                FechaExpedicionConyuge = processModel.FechaExpedicionConyuge.ToString(),
                FechaExpedicionSolicitante = processModel.FechaExpedicionSolicitante.ToString(),

                VFechaSolicitante = processModel.VFechaSolicitante.ToString(),
                VArchivoSolicitanteNombre = processModel.VArchivoSolicitante,
                VFechaConyuge = processModel.VFechaConyuge.ToString(),
                VArchivoConyugeNombre = processModel.VArchivoConyuge,


                PFechaSolicitante = processModel.PFechaSolicitante.ToString(),
                PArchivoSolicitanteNombre = processModel.PArchivoSolicitante,
                PFechaConyuge = processModel.PFechaConyuge.ToString(),
                PArchivoConyugeNombre = processModel.PArchivoConyuge,


                CFechaSolicitante = processModel.CFechaSolicitante.ToString(),
                CArchivoSolicitanteNombre = processModel.CArchivoSolicitante,
                CFechaConyuge = processModel.CFechaConyuge.ToString(),
                CArchivoConyugeNombre = processModel.CArchivoConyuge,


                AFechaSolicitante = processModel.AFechaSolicitante.ToString(),
                AArchivoSolicitanteNombre = processModel.AArchivoSolicitante,
                AFechaConyuge = processModel.AFechaConyuge.ToString(),
                AArchivoConyugeNombre = processModel.AArchivoConyuge,


                Gestion = processModel.Gestion,
                IdAspNetUser = processModel.IdAspNetUser,
                NombretUser = processModel.NombretUser,
                RolUser = processModel.RolUser,
                Estado = processModel.Estado,
                FechaModificacion = processModel.FechaModificacion,
                FModificacionExp = processModel.FModificacionExp,
                VFModificacion = processModel.VFModificacion,
                PFModificacion = processModel.PFModificacion,
                CFModificacion = processModel.CFModificacion,
                AFModificacion = processModel.AFModificacion,

                RolLogin = processModel.RolLogin,
                UserLogin = processModel.UserLogin,


            };
            return View(Entity);
        }

        private CaracterizacionSolicitanteModel ValidarEntity(CaracterizacionSolicitanteViewModels ObjData) {
            CaracterizacionSolicitanteModel Entity = new CaracterizacionSolicitanteModel();

            if (ObjData.Id == 0) { Entity.Id = 0; } else { Entity.Id = ObjData.Id; }
            if (ObjData.IdExpediente == null) { Entity.IdExpediente = 0; } else { Entity.IdExpediente = ObjData.IdExpediente; }
            
            if (ObjData.NombreSolicitanteExpediente == null) { Entity.NombreSolicitanteExpediente = "N_A"; } else { Entity.NombreSolicitanteExpediente = ObjData.NombreSolicitanteExpediente; }
            if (ObjData.DocSolicitanteExpediente == null) { Entity.DocSolicitanteExpediente = "N_A"; } else { Entity.DocSolicitanteExpediente = ObjData.DocSolicitanteExpediente; }
            if (ObjData.IdTipoDocSolicitanteExpediente == 0) { Entity.IdTipoDocSolicitanteExpediente = 0; } else { Entity.IdTipoDocSolicitanteExpediente = ObjData.IdTipoDocSolicitanteExpediente; }
            if (ObjData.TipoDocSolicitanteExpediente == null) { Entity.TipoDocSolicitanteExpediente = "N_A"; } else { Entity.TipoDocSolicitanteExpediente = ObjData.TipoDocSolicitanteExpediente; }

            if (ObjData.NombreConyugeExpediente == null) { Entity.NombreConyugeExpediente = "N_A"; } else { Entity.NombreConyugeExpediente = ObjData.NombreConyugeExpediente; }
            if (ObjData.DocConyugeExpediente == null) { Entity.DocConyugeExpediente = "N_A"; } else { Entity.DocConyugeExpediente = ObjData.DocConyugeExpediente; }
            if (ObjData.IdTipoDocConyugeExpediente == 0) { Entity.IdTipoDocConyugeExpediente = 0; } else { Entity.IdTipoDocConyugeExpediente = ObjData.IdTipoDocConyugeExpediente; }
            if (ObjData.TipoDocConyugeExpediente == null) { Entity.TipoDocConyugeExpediente = "N_A"; } else { Entity.TipoDocConyugeExpediente = ObjData.TipoDocConyugeExpediente; }

            if (ObjData.NumeroExpediente == null) { Entity.NumeroExpediente = "N_A"; } else { Entity.NumeroExpediente = ObjData.NumeroExpediente; }
            if (ObjData.NombreSolicitante == null) { Entity.NombreSolicitante = "N_A"; } else { Entity.NombreSolicitante = ObjData.NombreSolicitante; }
            if (ObjData.TipoDocumento == null) { Entity.TipoDocumento = 0; } else { Entity.TipoDocumento = ObjData.TipoDocumento; }
            if (ObjData.NombreTipoDocumento == null) { Entity.NombreTipoDocumento = "N_A"; } else { Entity.NombreTipoDocumento = ObjData.NombreTipoDocumento; }
            if (ObjData.NumeroIdentificacion == null) { Entity.NumeroIdentificacion = 0; } else { Entity.NumeroIdentificacion = ObjData.NumeroIdentificacion; }
            if (ObjData.NombreConyuge == null) { Entity.NombreConyuge = "N_A"; } else { Entity.NombreConyuge = ObjData.NombreConyuge; }
            if (ObjData.TipoDocumentoConyuge == null) { Entity.TipoDocumentoConyuge = 0; } else { Entity.TipoDocumentoConyuge = ObjData.TipoDocumentoConyuge; }
            if (ObjData.NombreTipoDocumentoConyuge == null) { Entity.NombreTipoDocumentoConyuge = "N_A"; } else { Entity.NombreTipoDocumentoConyuge = ObjData.NombreTipoDocumentoConyuge; }
            if (ObjData.NumeroIdentificacionConyuge == null) { Entity.NumeroIdentificacionConyuge = 0; } else { Entity.NumeroIdentificacionConyuge = ObjData.NumeroIdentificacionConyuge; }

            if (ObjData.FechaExpedicionSolicitante == null) { Entity.FechaExpedicionSolicitante = DateTime.Parse("1900-01-01"); } else { Entity.FechaExpedicionSolicitante = DateTime.Parse(ObjData.FechaExpedicionSolicitante); }
            if (ObjData.FechaExpedicionConyuge == null) { Entity.FechaExpedicionConyuge = DateTime.Parse("1900-01-01"); } else { Entity.FechaExpedicionConyuge = DateTime.Parse(ObjData.FechaExpedicionConyuge); }

            if (ObjData.VFechaSolicitante == null) { Entity.VFechaSolicitante = DateTime.Parse("1900-01-01"); } else { Entity.VFechaSolicitante = DateTime.Parse(ObjData.VFechaSolicitante); }
            if (ObjData.VArchivoSolicitante == null) { Entity.VArchivoSolicitante = "N_A"; } else { Entity.VArchivoSolicitante = ObjData.VArchivoSolicitanteNombre; }
            if (ObjData.VFechaConyuge == null) { Entity.VFechaConyuge = DateTime.Parse("1900-01-01"); } else { Entity.VFechaConyuge = DateTime.Parse(ObjData.VFechaConyuge); }
            if (ObjData.VArchivoConyuge == null) { Entity.VArchivoConyuge = "N_A"; } else { Entity.VArchivoConyuge = ObjData.VArchivoConyugeNombre; }

            if (ObjData.PFechaSolicitante == null) { Entity.PFechaSolicitante = DateTime.Parse("1900-01-01"); } else { Entity.PFechaSolicitante = DateTime.Parse(ObjData.PFechaSolicitante); }
            if (ObjData.PArchivoSolicitante == null) { Entity.PArchivoSolicitante = "N_A"; } else { Entity.PArchivoSolicitante = ObjData.PArchivoSolicitanteNombre; }
            if (ObjData.PFechaConyuge == null) { Entity.PFechaConyuge = DateTime.Parse("1900-01-01"); } else { Entity.PFechaConyuge = DateTime.Parse(ObjData.PFechaConyuge); }
            if (ObjData.PArchivoConyuge == null) { Entity.PArchivoConyuge = "N_A"; } else { Entity.PArchivoConyuge = ObjData.PArchivoConyugeNombre; }

            if (ObjData.CFechaSolicitante == null) { Entity.CFechaSolicitante = DateTime.Parse("1900-01-01"); } else { Entity.CFechaSolicitante = DateTime.Parse(ObjData.CFechaSolicitante); }
            if (ObjData.CArchivoSolicitante == null) { Entity.CArchivoSolicitante = "N_A"; } else { Entity.CArchivoSolicitante = ObjData.CArchivoSolicitanteNombre; }
            if (ObjData.CFechaConyuge == null) { Entity.CFechaConyuge = DateTime.Parse("1900-01-01"); } else { Entity.CFechaConyuge = DateTime.Parse(ObjData.CFechaConyuge); }
            if (ObjData.CArchivoConyuge == null) { Entity.CArchivoConyuge = "N_A"; } else { Entity.CArchivoConyuge = ObjData.CArchivoConyugeNombre; }

            if (ObjData.AFechaSolicitante == null) { Entity.AFechaSolicitante = DateTime.Parse("1900-01-01"); } else { Entity.AFechaSolicitante = DateTime.Parse(ObjData.AFechaSolicitante) ; }
            if (ObjData.AArchivoSolicitante == null) { Entity.AArchivoSolicitante = "N_A"; } else { Entity.AArchivoSolicitante = ObjData.AArchivoSolicitanteNombre; }
            if (ObjData.AFechaConyuge == null) { Entity.AFechaConyuge = DateTime.Parse("1900-01-01"); } else { Entity.AFechaConyuge = DateTime.Parse(ObjData.AFechaConyuge) ; }
            if (ObjData.AArchivoConyuge == null) { Entity.AArchivoConyuge = "N_A"; } else { Entity.AArchivoConyuge = ObjData.AArchivoConyugeNombre; }

            if (ObjData.Gestion == null) { Entity.Gestion = 0; } else { Entity.Gestion = ObjData.Gestion; }
            if (ObjData.IdAspNetUser == null) { Entity.IdAspNetUser = "N_A"; } else { Entity.IdAspNetUser = ObjData.IdAspNetUser; }
            if (ObjData.NombretUser == null) { Entity.NombretUser = "N_A"; } else { Entity.NombretUser = ObjData.NombretUser; }
            if (ObjData.RolUser == null) { Entity.RolUser =  "N_A"; } else { Entity.RolUser = ObjData.RolUser; }
            if (ObjData.Estado == null) { Entity.Estado = true; } else { Entity.Estado = ObjData.Estado; }
            if (ObjData.FechaModificacion == null) { Entity.FechaModificacion = "1900-01-01"; } else { Entity.FechaModificacion = ObjData.FechaModificacion; }
            if (ObjData.FModificacionExp == null) { Entity.FModificacionExp = "1900-01-01"; } else { Entity.FModificacionExp = ObjData.FModificacionExp; }
            
            if (ObjData.VFModificacion == null) { Entity.VFModificacion = "1900-01-01"; } else { Entity.VFModificacion = ObjData.VFModificacion; }
            if (ObjData.PFModificacion == null) { Entity.PFModificacion = "1900-01-01"; } else { Entity.PFModificacion = ObjData.PFModificacion; }
            if (ObjData.CFModificacion == null) { Entity.CFModificacion = "1900-01-01"; } else { Entity.CFModificacion = ObjData.CFModificacion; }
            if (ObjData.AFModificacion == null) { Entity.AFModificacion = "1900-01-01"; } else { Entity.AFModificacion = ObjData.AFModificacion; }

            if (ObjData.RolLogin == null) { Entity.RolLogin = "N_A"; } else { Entity.RolLogin = ObjData.RolLogin; }
            if (ObjData.UserLogin == null) { Entity.UserLogin = "N_A"; } else { Entity.UserLogin = ObjData.UserLogin; }

            return Entity;
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(CaracterizacionSolicitanteViewModels ObjData)
        {
            string Id = GetTokenObject().nameid;
            string Controller = "CaracterizacionSolicitante";
            string Method = "CaracterizacionSolicitanteupdate";

            var ruta = Server.MapPath("~/Content/Pdfs/Solicitantes");
            DateTime fecha = DateTime.Now;
            string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year + "-" + fecha.Hour + "-" + fecha.Minute + "-" + fecha.Second + "-" + fecha.Millisecond;

            CaracterizacionSolicitanteModel ValidarEntity_ = ValidarEntity(ObjData);

            if (ValidarEntity_.Gestion == 2)
            {
                if (ObjData.VArchivoSolicitante != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.VArchivoSolicitante;
                    var ext = Path.GetExtension(ObjData.VArchivoSolicitante.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("V_{0}_S_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.VArchivoSolicitante = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }

                if (ObjData.VArchivoConyuge != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.VArchivoConyuge;
                    var ext = Path.GetExtension(ObjData.VArchivoConyuge.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("V_{0}_C_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.VArchivoConyuge = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }

                ValidarEntity_.FModificacionExp = DateTime.Now.ToString();
            }

            if (ValidarEntity_.Gestion == 3)
            {
                if (ObjData.PArchivoSolicitante != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.PArchivoSolicitante;
                    var ext = Path.GetExtension(ObjData.PArchivoSolicitante.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("P_{0}_S_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.PArchivoSolicitante = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }

                if (ObjData.PArchivoConyuge != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.PArchivoConyuge;
                    var ext = Path.GetExtension(ObjData.PArchivoConyuge.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("P_{0}_C_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.PArchivoConyuge = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }
            }

            if (ValidarEntity_.Gestion == 4)
            {
                if (ObjData.CArchivoSolicitante != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.CArchivoSolicitante;
                    var ext = Path.GetExtension(ObjData.CArchivoSolicitante.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("C_{0}_S_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.CArchivoSolicitante = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }

                if (ObjData.CArchivoConyuge != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.CArchivoConyuge;
                    var ext = Path.GetExtension(ObjData.CArchivoConyuge.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("C_{0}_C_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.CArchivoConyuge = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }
            }

            if (ValidarEntity_.Gestion == 5)
            {
                if (ObjData.AArchivoSolicitante != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.AArchivoSolicitante;
                    var ext = Path.GetExtension(ObjData.AArchivoSolicitante.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("A_{0}_S_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.AArchivoSolicitante = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }

                if (ObjData.AArchivoConyuge != null)
                {
                    HttpPostedFileBase fileSoporte = ObjData.AArchivoConyuge;
                    var ext = Path.GetExtension(ObjData.AArchivoConyuge.FileName);

                    if (fileSoporte.ContentLength > 0)
                    {
                        string filename = string.Format("A_{0}_C_F_{1}{2}", ValidarEntity_.Id, FechaFor, ext);
                        ValidarEntity_.AArchivoConyuge = filename;

                        filename = Path.Combine(ruta, filename);
                        fileSoporte.SaveAs(filename);
                    }

                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ValidarEntity_);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    CaracterizacionSolicitanteModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionSolicitanteModel>(jsonResult.ToString());
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
            string Controller = "CaracterizacionSolicitante";
            string Method = "getCaracterizacionSolicitanteid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            CaracterizacionSolicitanteModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionSolicitanteModel>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CaracterizacionSolicitante";
            string Method = "getCaracterizacionSolicitanteid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            CaracterizacionSolicitanteModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionSolicitanteModel>(jsonResult.ToString());
            return View(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(CaracterizacionSolicitanteModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CaracterizacionSolicitante";
            string Method = "getCaracterizacionSolicitantedelete";
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