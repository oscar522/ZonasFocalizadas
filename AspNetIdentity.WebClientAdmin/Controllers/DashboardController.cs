using AspNetIdentity.WebClientAdmin.Providers;
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
using System.Data;
using System.Linq.Expressions;
using System.Dynamic;
using LinqLib.Sequence;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
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

        public ActionResult Index()
        {
            //string Id = GetTokenObject().nameid;
            //string Controller = "CaracterizacionSolicitante";
            //string Method = "getCaracterizacionSolicitanteidUser";
            //string result = await employeeProvider.Get(Id, Controller, Method);
            //var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            //List<CaracterizacionSolicitanteModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionSolicitanteModel>>(jsonResult.ToString());
            return View();

        }

        public ActionResult Rezago(int IdTable)
        {
            //string Id = GetTokenObject().nameid;
            //string Controller = "CaracterizacionSolicitante";
            //string Method = "getCaracterizacionSolicitanteidUser";
            //string result = await employeeProvider.Get(Id, Controller, Method);
            //var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            //List<CaracterizacionSolicitanteModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionSolicitanteModel>>(jsonResult.ToString());
            return View();

        }

        public ActionResult Barrido(int IdTable)
        {
            //string Id = GetTokenObject().nameid;
            //string Controller = "CaracterizacionSolicitante";
            //string Method = "getCaracterizacionSolicitanteidUser";
            //string result = await employeeProvider.Get(Id, Controller, Method);
            //var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            //List<CaracterizacionSolicitanteModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionSolicitanteModel>>(jsonResult.ToString());
            return View();

        }

       


        /// <summary>
        /// viejo
        /// </summary>
        /// <returns></returns>

        public async Task<ActionResult> CountDepto()
        {

            string Id = "0";
            string Controller = "Administrator";
            string Method = "getAdministratorCountDeptoMuni";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtCiudadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtCiudadModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ConsultarGestion(string TypeTable, string Fi, string Ff, string Mes, int Dia , string users)
        {
            users = users + GetTokenObject().nameid;
            DateTime fecha = DateTime.Now;
            string FechaFor = fecha.Day + "-" + fecha.Month + "-" + fecha.Year + "-" + fecha.Hour + "-" + fecha.Minute + "-" + fecha.Second + "-" + fecha.Millisecond;
            string Id = TypeTable + "_" + Fi + "_" + Ff + "_" + Mes + "_" + Dia + "_" + users+"-"+FechaFor;
            string Controller = "Administrator";
            string Method = "getConsultarGestion";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PlGestionUsersModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PlGestionUsersModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public class Gestion {

            public string fecha { get; set; }
            public List<object> row { get; set; } 
        
        }
       
        public async Task<ActionResult> CountDeptoMuni()
        {
            string Id = "0";
            string Controller = "Administrator";
            string Method = "getAdministratorCountDeptoMuni";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtCiudadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtCiudadModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ResumenAll(string Depto)
        {
            string Id = "76" + "_" + "275" + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "getResumenAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ResumenTipificacionAllModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenTipificacionAllModel>>(jsonResult.ToString());
            List<ResumenTipificacionVistaModel> Resumen = new List<ResumenTipificacionVistaModel>();
            if (Depto.Equals("N_A"))
            {
                Resumen = processModel
                    .GroupBy(z => z.Grupo)
                    .Select(c => new ResumenTipificacionVistaModel
                    {
                        Total = c.Count(),
                        Grupo = c.Select(v => v.Grupo).FirstOrDefault(),
                        //Plano = processModel.Where(x => x.Plano == 21 && x.Grupo == c.Select(v => v.Grupo).FirstOrDefault()).Count(),
                        Plano = c.Where(v => v.Plano != null).Count(),
                        Orden = c.Select(v => v.Orden).FirstOrDefault(),
                        Municipio = c.Select(v => v.MunicNombre).FirstOrDefault(),
                        IdMunicipio = c.Select(v => v.MunicId.Value).FirstOrDefault(),
                        Depto = c.Select(v => v.DeptoNombre).FirstOrDefault(),
                        IdDepto = c.Select(v => v.DeptoId.Value).FirstOrDefault(),
                    }).ToList();
            }
            else{
                Resumen = processModel
                    .Where(f=>f.DeptoNombre == Depto.ToUpper())
                    .GroupBy(z => z.Grupo)
                    .Select(c => new ResumenTipificacionVistaModel
                    {
                        Total = c.Count(),
                        Grupo = c.Select(v => v.Grupo).FirstOrDefault(),
                        //Plano = processModel.Where(x => x.Plano == 21 && x.Grupo == c.Select(v => v.Grupo).FirstOrDefault()).Count(),
                        Plano = c.Where(v => v.Plano != null).Count(),
                        Orden = c.Select(v => v.Orden).FirstOrDefault(),
                        Municipio = c.Select(v => v.MunicNombre).FirstOrDefault(),
                        IdMunicipio = c.Select(v => v.MunicId.Value).FirstOrDefault(),
                        Depto = c.Select(v => v.DeptoNombre).FirstOrDefault(),
                        IdDepto = c.Select(v => v.DeptoId.Value).FirstOrDefault(),
                    }).ToList();
            }

            
            return Json(Resumen, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CaracterizacionSolicitante()
        {
            string Id = "0";
            string Controller = "CaracterizacionSolicitante";
            string Method = "getCaracterizacionSolicitante";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionSolicitanteModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionSolicitanteModel>>(jsonResult.ToString());
            var Resumen = processModel
                            .GroupBy(z => z.Gestion)
                              .Select(c => new ResumenTipificacionVistaModel
                              {
                                  Total = c.Count(),
                                  Grupo = c.Select(v => v.Gestion.ToString()).FirstOrDefault(),
                                  Plano = processModel.Where(x => x.IdAspNetUser != null).Count(),
                              }).ToList();
            return Json(Resumen, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> getCaracterizacionJuridica()
        {
            string Id = "0";
            string Controller = "CaracterizacionJuridica";
            string Method = "getCaracterizacionJuridica";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionJuridicaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaModel>>(jsonResult.ToString());

            var Resumen = processModel
                            .Select(x => x)
                            .GroupBy(z => z.Gestion)
                              .Select(c => new ResumenTipificacionVistaModel
                              {
                                  Total = c.Count(),
                                  Grupo = c.Select(v => v.Gestion.ToString()).FirstOrDefault(),
                                  Plano = processModel.Where(x => x.IdAspNetUser != null).Count(),
                              }).ToList();
            return Json(Resumen, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> getCaracterizacionRegistro()
        {
            string Id = "0";
            string Controller = "Registro";
            string Method = "getRegistro";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RegistroModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegistroModel>>(jsonResult.ToString());

            var Resumen = processModel
                            .Select(x => x)
                            .GroupBy(z => z.Estado)
                              .Select(c => new ResumenTipificacionVistaModel
                              {
                                  Total = c.Count(),
                                  Grupo = c.Select(v => v.Estado.ToString()).FirstOrDefault(),
                                  Plano = processModel.Where(x => x.IdAspNetUser != null).Count(),
                              }).ToList();
            return Json(Resumen, JsonRequestBehavior.AllowGet);
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
                NumeroExpediente = processModel.NumeroExpediente,
                IdDepto = processModel.IdDepto,
                NombreDepto = processModel.NombreDepto,
                IdMunicipio = processModel.IdMunicipio,
                NombreMunicipio = processModel.NombreMunicipio,


                NombreSolicitanteExpediente = processModel.NombreSolicitanteExpediente,
                DocSolicitanteExpediente = processModel.DocSolicitanteExpediente,
                IdTipoDocSolicitanteExpediente = processModel.IdTipoDocSolicitanteExpediente,
                TipoDocSolicitanteExpediente = processModel.TipoDocSolicitanteExpediente,

                NombreConyugeExpediente = processModel.NombreConyugeExpediente,
                DocConyugeExpediente = processModel.DocConyugeExpediente,
                IdTipoDocConyugeExpediente = processModel.IdTipoDocConyugeExpediente,
                TipoDocConyugeExpediente = processModel.TipoDocConyugeExpediente,

                CedulaExpSol = processModel.CedulaExpSol,
                DocVisibleSol = processModel.DocVisibleSol,
                NombreSolicitante = processModel.NombreSolicitante,
                TipoDocumento = processModel.TipoDocumento,
                NombreTipoDocumento = processModel.NombreTipoDocumento,
                NumeroIdentificacion = processModel.NumeroIdentificacion,
                FechaExpedicionSolicitante = processModel.FechaExpedicionSolicitante.ToString(),

                CedulaExpCon = processModel.CedulaExpCon,
                DocVisibleCon = processModel.DocVisibleCon,
                NombreConyuge = processModel.NombreConyuge,
                TipoDocumentoConyuge = processModel.TipoDocumentoConyuge,
                NombreTipoDocumentoConyuge = processModel.NombreTipoDocumentoConyuge,
                NumeroIdentificacionConyuge = processModel.NumeroIdentificacionConyuge,
                FechaExpedicionConyuge = processModel.FechaExpedicionConyuge.ToString(),


                VFechaSolicitante = processModel.VFechaSolicitante.ToString(),
                VArchivoSolicitanteNombre = processModel.VArchivoSolicitante,
                VVivoSolicitante = processModel.VVivoSolicitante,

                VFechaConyuge = processModel.VFechaConyuge.ToString(),
                VArchivoConyugeNombre = processModel.VArchivoConyuge,
                VVivoConyuge= processModel.VVivoConyuge,


                PFechaSolicitante = processModel.PFechaSolicitante.ToString(),
                PArchivoSolicitanteNombre = processModel.PArchivoSolicitante,
                PInhabilidadSolicitante = processModel.PInhabilidadSolicitante,

                PFechaConyuge = processModel.PFechaConyuge.ToString(),
                PArchivoConyugeNombre = processModel.PArchivoConyuge,
                PInhabilidadConyuge = processModel.PInhabilidadConyuge,


                CFechaSolicitante = processModel.CFechaSolicitante.ToString(),
                CArchivoSolicitanteNombre = processModel.CArchivoSolicitante,
                CInhabilidadSolicitante = processModel.CInhabilidadSolicitante,

                CFechaConyuge = processModel.CFechaConyuge.ToString(),
                CArchivoConyugeNombre = processModel.CArchivoConyuge,
                CInhabilidadConyuge = processModel.CInhabilidadConyuge,


                AFechaSolicitante = processModel.AFechaSolicitante.ToString(),
                AArchivoSolicitanteNombre = processModel.AArchivoSolicitante,
                AInhabilidadSolicitante = processModel.AInhabilidadSolicitante,

                AFechaConyuge = processModel.AFechaConyuge.ToString(),
                AArchivoConyugeNombre = processModel.AArchivoConyuge,
                AInhabilidadConyuge = processModel.AInhabilidadConyuge,


                Gestion = processModel.Gestion,
                IdAspNetUser = processModel.IdAspNetUser,
                NombretUser = processModel.NombretUser,
                RolUser = processModel.RolUser,
                Estado = processModel.Estado,
                RolLogin = processModel.RolLogin,
                UserLogin = processModel.UserLogin,
            };
            return View(Entity);
        }

        private CaracterizacionSolicitanteModel ValidarEntity(CaracterizacionSolicitanteViewModels ObjData) {
            CaracterizacionSolicitanteModel Entity = new CaracterizacionSolicitanteModel();

            if (ObjData.Id == 0) { Entity.Id= 0; } else { Entity.Id = ObjData.Id; }
            if (ObjData.IdExpediente == null) { Entity.IdExpediente= 0; } else { Entity.IdExpediente = ObjData.IdExpediente;}
            if (ObjData.NumeroExpediente == null) { Entity.NumeroExpediente = "N_A"; } else { Entity.NumeroExpediente = ObjData.NumeroExpediente;}
            if (ObjData.IdDepto == 0) { Entity.IdDepto= 0; } else { Entity.IdDepto = ObjData.IdDepto;}
            if (ObjData.NombreDepto == null) { Entity.NombreDepto= "N_A"; } else { Entity.NombreDepto = ObjData.NombreDepto;}
            if (ObjData.IdMunicipio == 0) { Entity.IdMunicipio= 0; } else { Entity.IdMunicipio = ObjData.IdMunicipio;}
            if (ObjData.NombreMunicipio == null) { Entity.NombreMunicipio= "N_A"; } else { Entity.NombreMunicipio = ObjData.NombreMunicipio;}


            if (ObjData.NombreSolicitanteExpediente ==null){ Entity.NombreSolicitanteExpediente ="N_A"; } else{ Entity.NombreSolicitanteExpediente = ObjData.NombreSolicitanteExpediente;}
            if (ObjData.DocSolicitanteExpediente ==null){ Entity.DocSolicitanteExpediente = "N_A"; } else{ Entity.DocSolicitanteExpediente = ObjData.DocSolicitanteExpediente;}
            if (ObjData.IdTipoDocSolicitanteExpediente ==0){ Entity.IdTipoDocSolicitanteExpediente = 1; } else{ Entity.IdTipoDocSolicitanteExpediente = ObjData.IdTipoDocSolicitanteExpediente;}
            if (ObjData.TipoDocSolicitanteExpediente ==null){ Entity.TipoDocSolicitanteExpediente = "N_A"; } else{ Entity.TipoDocSolicitanteExpediente = ObjData.TipoDocSolicitanteExpediente;}

            if (ObjData.NombreConyugeExpediente ==null){ Entity.NombreConyugeExpediente = "N_A"; } else{ Entity.NombreConyugeExpediente = ObjData.NombreConyugeExpediente;}
            if (ObjData.DocConyugeExpediente ==null){ Entity.DocConyugeExpediente = "N_A"; } else{ Entity.DocConyugeExpediente = ObjData.DocConyugeExpediente;}
            if (ObjData.IdTipoDocConyugeExpediente ==0){ Entity.IdTipoDocConyugeExpediente = 0; } else{ Entity.IdTipoDocConyugeExpediente = ObjData.IdTipoDocConyugeExpediente;}
            if (ObjData.TipoDocConyugeExpediente ==null){ Entity.TipoDocConyugeExpediente = "N_A"; } else{ Entity.TipoDocConyugeExpediente = ObjData.TipoDocConyugeExpediente;}


            if (ObjData.CedulaExpCon == null) { Entity.CedulaExpCon = 0; } else { Entity.CedulaExpCon = ObjData.CedulaExpCon; }
            if (ObjData.DocVisibleCon == null) { Entity.DocVisibleCon = 0; } else { Entity.DocVisibleCon = ObjData.DocVisibleCon; }
            if (ObjData.NombreConyuge == null) { Entity.NombreConyuge = "N_A"; } else { Entity.NombreConyuge = ObjData.NombreConyuge; }
            if (ObjData.NumeroIdentificacionConyuge == null) { Entity.NumeroIdentificacionConyuge = 0; } else { Entity.NumeroIdentificacionConyuge = ObjData.NumeroIdentificacionConyuge; }
            if (ObjData.TipoDocumentoConyuge == null || ObjData.TipoDocumentoConyuge == 0) { Entity.TipoDocumentoConyuge = 1; } else { Entity.TipoDocumentoConyuge = ObjData.TipoDocumentoConyuge; }
            if (ObjData.NombreTipoDocumentoConyuge == null) { Entity.NombreTipoDocumentoConyuge = "N_A"; } else { Entity.NombreTipoDocumentoConyuge = ObjData.NombreTipoDocumentoConyuge; }
            if (ObjData.FechaExpedicionConyuge == null) { Entity.FechaExpedicionConyuge = DateTime.Parse("1900-01-01"); } else { Entity.FechaExpedicionConyuge = Convert.ToDateTime(ObjData.FechaExpedicionConyuge); }

            if (ObjData.CedulaExpSol == null) { Entity.CedulaExpSol = 0; } else { Entity.CedulaExpSol = ObjData.CedulaExpSol; }
            if (ObjData.DocVisibleSol == null) { Entity.DocVisibleSol = 0; } else { Entity.DocVisibleSol = ObjData.DocVisibleSol; }
            if (ObjData.NombreSolicitante == null) { Entity.NombreSolicitante = "N_A"; } else { Entity.NombreSolicitante = ObjData.NombreSolicitante; }
            if (ObjData.NumeroIdentificacion == null) { Entity.NumeroIdentificacion = 0; } else { Entity.NumeroIdentificacion = ObjData.NumeroIdentificacion; }
            if (ObjData.TipoDocumento == null || ObjData.TipoDocumento == null ) { Entity.TipoDocumento = 1; } else { Entity.TipoDocumento = ObjData.TipoDocumento; }
            if (ObjData.NombreTipoDocumento == null) { Entity.NombreTipoDocumento = "N_A"; } else { Entity.NombreTipoDocumento = ObjData.NombreTipoDocumento; }
            if (ObjData.FechaExpedicionSolicitante == null) { Entity.FechaExpedicionSolicitante = DateTime.Parse("1900-01-01"); } else { Entity.FechaExpedicionSolicitante = Convert.ToDateTime(ObjData.FechaExpedicionSolicitante); }


            if (ObjData.VFechaSolicitante ==null){ Entity.VFechaSolicitante = DateTime.Parse("1900-01-01") ;} else {Entity.VFechaSolicitante =Convert.ToDateTime(ObjData.VFechaSolicitante);}
            if (ObjData.VArchivoSolicitanteNombre ==null){ Entity.VArchivoSolicitante = "N_A" ;} else {Entity.VArchivoSolicitante =ObjData.VArchivoSolicitanteNombre;}
            if (ObjData.VVivoSolicitante ==null){ Entity.VVivoSolicitante = 0 ;} else {Entity.VVivoSolicitante =ObjData.VVivoSolicitante;}

            if (ObjData.VFechaConyuge ==null){ Entity.VFechaConyuge = DateTime.Parse("1900-01-01") ;} else {Entity.VFechaConyuge =Convert.ToDateTime(ObjData.VFechaConyuge);}
            if (ObjData.VArchivoConyugeNombre ==null){ Entity.VArchivoConyuge = "N_A" ;} else {Entity.VArchivoConyuge =ObjData.VArchivoConyugeNombre;}
            if (ObjData.VVivoConyuge== null){Entity.VVivoConyuge = 0 ;} else {Entity.VVivoConyuge =ObjData.VVivoConyuge;}


            if (ObjData.PFechaSolicitante ==null){ Entity.PFechaSolicitante = DateTime.Parse("1900-01-01"); }else{Entity.PFechaSolicitante = Convert.ToDateTime(ObjData.PFechaSolicitante);}
            if (ObjData.PArchivoSolicitanteNombre ==null){ Entity.PArchivoSolicitante = "N_A"; }else{Entity.PArchivoSolicitante = ObjData.PArchivoSolicitanteNombre;}
            if (ObjData.PInhabilidadSolicitante ==null){ Entity.PInhabilidadSolicitante = 0; }else{Entity.PInhabilidadSolicitante = ObjData.PInhabilidadSolicitante;}

            if (ObjData.PFechaConyuge ==null){ Entity.PFechaConyuge = DateTime.Parse("1900-01-01"); }else{Entity.PFechaConyuge = Convert.ToDateTime(ObjData.PFechaConyuge);}
            if (ObjData.PArchivoConyugeNombre ==null){ Entity.PArchivoConyuge = "N_A"; }else{Entity.PArchivoConyuge = ObjData.PArchivoConyugeNombre;}
            if (ObjData.PInhabilidadConyuge ==null){ Entity.PInhabilidadConyuge = 0; }else{Entity.PInhabilidadConyuge = ObjData.PInhabilidadConyuge;}


            if (ObjData.CFechaSolicitante ==null){ Entity.CFechaSolicitante = DateTime.Parse("1900-01-01"); }else{Entity.CFechaSolicitante = Convert.ToDateTime(ObjData.CFechaSolicitante);}
            if (ObjData.CArchivoSolicitanteNombre ==null){ Entity.CArchivoSolicitante = "N_A"; }else{Entity.CArchivoSolicitante = ObjData.CArchivoSolicitanteNombre;}
            if (ObjData.CInhabilidadSolicitante ==null){ Entity.CInhabilidadSolicitante = 0; }else{Entity.CInhabilidadSolicitante = ObjData.CInhabilidadSolicitante;}

            if (ObjData.CFechaConyuge ==null){ Entity.CFechaConyuge = DateTime.Parse("1900-01-01"); }else{Entity.CFechaConyuge = Convert.ToDateTime(ObjData.CFechaConyuge);}
            if (ObjData.CArchivoConyugeNombre ==null){ Entity.CArchivoConyuge = "N_A"; }else{Entity.CArchivoConyuge = ObjData.CArchivoConyugeNombre;}
            if (ObjData.CInhabilidadConyuge ==null){ Entity.CInhabilidadConyuge = 0; }else{Entity.CInhabilidadConyuge = ObjData.CInhabilidadConyuge;}

            if (ObjData.AFechaSolicitante == null ) {  Entity.AFechaSolicitante = DateTime.Parse("1900-01-01") ;  }else{Entity.AFechaSolicitante = Convert.ToDateTime(ObjData.AFechaSolicitante);}
            if (ObjData.AArchivoSolicitanteNombre == null ) {  Entity.AArchivoSolicitante = "N_A";  }else{Entity.AArchivoSolicitante = ObjData.AArchivoSolicitanteNombre;}
            if (ObjData.AInhabilidadSolicitante == null ) {  Entity.AInhabilidadSolicitante = 0 ;  }else{Entity.AInhabilidadSolicitante = ObjData.AInhabilidadSolicitante;}

            if (ObjData.AFechaConyuge == null ) {  Entity.AFechaConyuge = DateTime.Parse("1900-01-01") ;  }else{Entity.AFechaConyuge = Convert.ToDateTime(ObjData.AFechaConyuge);}
            if (ObjData.AArchivoConyugeNombre == null ) {  Entity.AArchivoConyuge = "N_A" ;  }else{Entity.AArchivoConyuge = ObjData.AArchivoConyugeNombre;}
            if (ObjData.AInhabilidadConyuge == null ) {  Entity.AInhabilidadConyuge = 0 ;  }else{Entity.AInhabilidadConyuge = ObjData.AInhabilidadConyuge;}


            if (ObjData.Gestion == null ) {  Entity.Gestion = 0;  }else{Entity.Gestion = ObjData.Gestion;}
            if (ObjData.IdAspNetUser == null ) {  Entity.IdAspNetUser = "N_A" ;  }else{Entity.IdAspNetUser = ObjData.IdAspNetUser;}
            if (ObjData.NombretUser == null ) {  Entity.NombretUser = "N_A" ;  }else{Entity.NombretUser = ObjData.NombretUser;}
            if (ObjData.RolUser == null ) {  Entity.RolUser = "N_A" ;  }else{Entity.RolUser = ObjData.RolUser;}
            if (ObjData.Estado == null ) {  Entity.Estado = false;  }else{Entity.Estado = ObjData.Estado;}
            if (ObjData.RolLogin == null ) {  Entity.RolLogin = "N_A";  }else{Entity.RolLogin = ObjData.RolLogin;}
            if (ObjData.UserLogin == null ) {  Entity.UserLogin ="N_A" ;  }else{Entity.UserLogin = ObjData.UserLogin;}

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