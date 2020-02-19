using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize] 
    public class HomeAdministratorController : BaseController
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

        public async Task<ActionResult> CountDeptos()
        {
            string Id = "0";
            string Controller = "Administrator";
            string Method = "getAdministratorCountDeptos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtCiudadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtCiudadModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Resumen(int IdDepto, int IdCiudad)
        {
            string Id = IdDepto+"_"+IdCiudad+"_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "getResumen";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ResumenTipificacionModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenTipificacionModel>>(jsonResult.ToString());

            var Resumen = processModel
                            .GroupBy(z => z.Grupo)
                              .Select(c => new ResumenTipificacionVistaModel
                              { 
                                  Total = c.Count(),
                                  Grupo = c.Select(v => v.Grupo).FirstOrDefault(),
                                  //Plano = processModel.Where(x => x.Plano == 21 && x.Grupo == c.Select(v => v.Grupo).FirstOrDefault()).Count(),
                                  Plano = c.Where(v => v.Plano == 21 ).Count(),
                                  Orden = c.Select(v => v.Orden).FirstOrDefault(),
                                  Municipio = c.Select(v => v.Municipio).FirstOrDefault(),
                                  IdMunicipio = c.Select(v => v.IdMunicipio).FirstOrDefault(),
                                  Depto = c.Select(v => v.Depto).FirstOrDefault(),
                                  IdDepto  = c.Select(v => v.IdDepto).FirstOrDefault(),
                              })
                          
                          .ToList();

            //var Resumen2 = Resumen
            //             .Select(c => new ResumenTipificacionVistaModel
            //             {
            //                 Total = c.Total,
            //                 Grupo = c.Grupo,
            //                 Plano = processModel.Where(x => x.Plano == 21 && x.Grupo == c.Grupo).Count(),
            //                 Orden = c.Orden,
            //                 Municipio = c.Municipio,
            //                 IdMunicipio = c.IdMunicipio,
            //                 Depto = c.Depto,
            //                 IdDepto = c.IdDepto,
            //             }).ToList();
            //var Resument = new List<ResumenTipificacionVistaModel>();

            //int Archivo = 0;
            //int DecideAdjudica = 0;
            //int DecideNiega = 0;
            //int InspecionOcular = 0;
            //int Nulidades = 0;
            //int Oposición = 0;
            //int Recursos = 0;
            //int Registro = 0;
            //int Solicitudes = 0;

            //int gArchivo = 0;
            //int gDecideAdjudica = 0;
            //int gDecideNiega = 0;
            //int gInspecionOcular = 0;
            //int gNulidades = 0;
            //int gOposición = 0;
            //int gRecursos = 0;
            //int gRegistro = 0;
            //int gSolicitudes = 0;

            //foreach (var item in processModel) {
            //    if (item.Grupo.Equals("Archivo"))
            //    {
            //        gArchivo++;
            //        if (item.Plano.Value == 21 )
            //        {
            //            Archivo++;
            //        }
            //    } else  

            //    Archivo
            //    Decide Adjudica
            //    Decide Niega
            //    Inspeción Ocular
            //    Nulidades
            //    Oposición
            //    Recursos
            //    Registro
            //    Solicitudes


            //}

            return View("ResumenIndex", Resumen);
        }

        public async Task<ActionResult> ResumenRegistro(int IdDepto, int IdCiudad)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "getResumenRegistro";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ResumenTipificacionModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenTipificacionModel>>(jsonResult.ToString());

            var Resumen = processModel
                          .GroupBy(z => z.Grupo)
                          .Select(c => new ResumenTipificacionVistaModel
                          {
                              Total = c.Count(),
                              Grupo = c.Select(v => v.Grupo).FirstOrDefault(),
                              Plano = processModel.Where(x => x.Plano == 21 && x.Grupo == c.Select(v => v.Grupo).FirstOrDefault()).Count(),
                              Orden = c.Select(v => v.Orden).FirstOrDefault(),
                              IdMunicipio = c.Select(v => v.IdMunicipio).FirstOrDefault(),
                              IdDepto = c.Select(v => v.IdDepto).FirstOrDefault(),

                          }).ToList();

            return Json(Resumen, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ResumenRegistroLista(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenRegistroLista";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResumenLista", processModel);
        }

        public async Task<ActionResult> ResumenLista(int IdDepto, int IdCiudad, string Grupo)
            {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenLista";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResumenLista", processModel);
        }

        public async Task<ActionResult> ResumenListaPlano(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaPlano";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResumenLista", processModel);
        }

        public async Task<ActionResult> CountEdit()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalCountEdit";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            int processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(jsonResult.ToString());
            return Json(processModel);
        }

        public ActionResult ResumenIndex(int IdDeptoIn, int IdCiudadIn)
        {
            return Json(new { result = "Redirect", url = Url.Action("Resumen", "HomeAdministrator", new { IdDepto = IdDeptoIn, IdCiudad = IdCiudadIn }) });
        }
        
        public ActionResult Index()
        {
            return View();

        }

        public async Task<ActionResult> ResumenListaSinPlano(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaSinPlano";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResumenLista", processModel);
        }

        public async Task<ActionResult> ResumenListaConPlano(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaConPlano";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResumenLista", processModel);
        }

    }
}