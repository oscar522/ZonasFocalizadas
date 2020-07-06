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

        public async Task<ActionResult> CountDepto()
        {
            string Id = "0";
            string Controller = "Administrator";
            string Method = "getAdministratorCountDepto";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtCiudadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtCiudadModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Resumen(int IdDepto, int IdCiudad)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid;
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
                                  Plano = c.Where(v => v.Plano == 21).Count(),
                                  Orden = c.Select(v => v.Orden).FirstOrDefault(),
                                  Municipio = c.Select(v => v.Municipio).FirstOrDefault(),
                                  IdMunicipio = c.Select(v => v.IdMunicipio).FirstOrDefault(),
                                  Depto = c.Select(v => v.Depto).FirstOrDefault(),
                                  IdDepto = c.Select(v => v.IdDepto).FirstOrDefault(),
                              })

                          .ToList();

            return View("ResumenIndex", Resumen);
        }

        public async Task<ActionResult> ResumenAll()
        {
            string Id = "76" + "_" + "275" + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "getResumenAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ResumenTipificacionAllModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenTipificacionAllModel>>(jsonResult.ToString());

            var Resumen = processModel
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

             return View("ResumenAllIndex", Resumen);
        }

        public async Task<ActionResult> ResumenCaracterizacionAll()
        {
            string Id = "76" + "_" + "275" + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());

            var Resumen = processModel
                            .GroupBy(z => z.IdAspNetUser)
                            .Select(c => new ResumenTipificacionVistaModel
                            {
                                Total = c.Count(),
                                Grupo = c.Select(v => v.IdAspNetUser).FirstOrDefault(),
                            }).ToList();

            return View("ResumenAllCaracterizacionIndex", Resumen);
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

        public async Task<ActionResult> ResumenRegistroAll(int IdDepto, int IdCiudad)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "getResumenRegistroAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ResumenTipificacionAllModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenTipificacionAllModel>>(jsonResult.ToString());

            var Resumen = processModel
                          .GroupBy(z => z.Grupo)
                          .Select(c => new ResumenTipificacionVistaModel
                          {
                              Total = c.Select(v => v.IdExpediente).Count(),
                              Grupo = c.Select(v => v.Grupo).FirstOrDefault(),
                              Plano = c.Where(v => v.Plano != 0).Count(),
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

        public async Task<ActionResult> ResumenListaAll(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaAll";
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

        public async Task<ActionResult> ResumenListaPlanoAll(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaPlanoAll";
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

        public ActionResult IndexDepto()
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

        public async Task<ActionResult> ResumenListaSinPlanoAll(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaSinPlanoAll";
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

        public async Task<ActionResult> ResumenListaConPlanoAll(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaConPlanoAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResumenLista", processModel);
        }

    }
}