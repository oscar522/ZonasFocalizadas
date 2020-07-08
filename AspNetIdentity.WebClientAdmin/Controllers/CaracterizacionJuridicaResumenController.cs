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
    public class CaracterizacionJuridicaResumenController : BaseController
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

         public async Task<ActionResult> Resumen(int IdDepto, int IdCiudad)
         {
            string Id = "76" + "_" + "275" + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());

            var Resumen = processModel
                            .Where(x => x.IdMunicipio == IdCiudad && x.IdDepto == IdDepto.ToString())
                            .GroupBy(z => z.Tipo)
                            .Select(c => new ResumenTipificacionVistaModel
                            {
                                Total = c.Count(),
                                Grupo = c.Select(v => v.Tipo).FirstOrDefault(),
                                Municipio = c.Select(v => v.NombreMuni).FirstOrDefault(),
                                IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                                Depto = c.Select(v => v.NombreDepto).FirstOrDefault(),
                                IdDepto = Convert.ToInt32(c.Select(v => v.IdDepto).FirstOrDefault()),
                            }).ToList();


            return View("ResumenIndex", Resumen);
        }
        public async Task<ActionResult> ResumenJson(int IdDepto, int IdCiudad)
        {
            string Id = "76" + "_" + "275" + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());

            var Resumen = processModel
                            .Where(x => x.IdMunicipio == IdCiudad && x.IdDepto == IdDepto.ToString())
                            .GroupBy(z => z.Tipo)
                            .Select(c => new ResumenTipificacionVistaModel
                            {
                                Total = c.Count(),
                                Grupo = c.Select(v => v.Tipo).FirstOrDefault(),
                                Municipio = c.Select(v => v.NombreMuni).FirstOrDefault(),
                                IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                                Depto = c.Select(v => v.NombreDepto).FirstOrDefault(),
                                IdDepto = Convert.ToInt32(c.Select(v => v.IdDepto).FirstOrDefault()),
                            }).ToList();


            return Json(Resumen, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> ResumenCaracterizacionJuridicaAll()
        {
            string Id = "76" + "_" + "275" + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());

            var Resumen = processModel
                            .GroupBy(z => z.NombreMuni)
                            .Select(c => new ResumenTipificacionVistaModel
                            {
                                Total = c.Count(),
                                Grupo = c.Select(v => v.IdAspNetUser).FirstOrDefault(),
                                Municipio = c.Select(v => v.NombreMuni).FirstOrDefault(),
                                IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                                Depto = c.Select(v => v.NombreDepto).FirstOrDefault(),
                                IdDepto = Convert.ToInt32( c.Select(v => v.IdDepto).FirstOrDefault()),
                            }).ToList();

            return Json(Resumen, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ResumenLista(int IdDepto, int IdCiudad, string Grupo)
        {
            string Id = IdDepto + "_" + IdCiudad + "_" + GetTokenObject().nameid + "_" + Grupo;
            string Controller = "Administrator";
            string Method = "getResumenListaRegumenCaracterizacionJuridica";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("ResumenLista", processModel);
        }


        public async Task<ActionResult> ResumenListaDetalleRECURSOS(int IdDeptoIn, int IdCiudadIn, string GrupoIn)
        {
            string Id = IdDeptoIn + "_" + IdCiudadIn + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            List<CaracterizacionJuridicaResumenModel> Result = new List<CaracterizacionJuridicaResumenModel> ();

            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());
            if (GrupoIn == "NOTIFICACIONES")
            {
                var ResultFind = processModel.Where(x => x.Tipo == GrupoIn && x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                Result = ResultFind
                           .GroupBy(z => z.SubTipo)
                           .Select(c => new CaracterizacionJuridicaResumenModel
                           {
                               Orden = c.Count(),
                               RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.SubTipo).FirstOrDefault(),
                               IdAspNetUser = c.Select(v => v.NombreMuni).FirstOrDefault(),
                               IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                               NombreMuni = c.Select(v => v.NombreDepto).FirstOrDefault(),
                               IdDepto = c.Select(v => v.IdDepto).FirstOrDefault(),
                           }).ToList();
            }

            if (GrupoIn == "RECURSOS")
            {
                var ResultFindRECURSOS = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRecursos = ResultFindRECURSOS.Where(x => x.Tipo == "RECURSOS").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRecursos
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.SubTipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                var ResultMinisterio = ResultResoluciones
               .Where(x => x.NombreMuni == "MINISTERIO")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_N_1 == 31 &&  x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                var ResultSolicitante = ResultResoluciones
               .Where(x => x.NombreMuni == "SOLICITANTE")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_N_1 == 31 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                Result = ResultMinisterio.Union(ResultSolicitante).ToList();
            }

            if (GrupoIn == "CONSTANCIA DE EJECUTORIA")
            {
                var ResultFindCONSTANCIA = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultCONSTANCIA = ResultFindCONSTANCIA.Where(x => x.Tipo == "CONSTANCIA DE EJECUTORIA").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultCONSTANCIA
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   //Borrosos
                   Orden = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }

            if (GrupoIn == "RESOLUCION")
            {
                var ResultFindRESOLUCION = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRESOLUCION = ResultFindRESOLUCION.Where(x => x.Tipo == "RESOLUCION").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRESOLUCION
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   ////Borrosos
                   //Orden = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   //{ l, m }).Where(x => x.l.RESOLUCION_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                   //         .ToList()
                   //         .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // datos solicitante bien 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_DATOS_SOLICITANTE_BIEN == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }


            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ResumenListaDetalle(int IdDeptoIn, int IdCiudadIn, string GrupoIn)
        {
            string Id = IdDeptoIn + "_" + IdCiudadIn + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            List<CaracterizacionJuridicaResumenModel> Result = new List<CaracterizacionJuridicaResumenModel>();

            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());
            if (GrupoIn == "NOTIFICACIONES")
            {
                var ResultFind = processModel.Where(x => x.Tipo == GrupoIn && x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                Result = ResultFind
                           .GroupBy(z => z.SubTipo)
                           .Select(c => new CaracterizacionJuridicaResumenModel
                           {
                               Orden = c.Count(),
                               RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.SubTipo).FirstOrDefault(),
                               IdAspNetUser = c.Select(v => v.NombreMuni).FirstOrDefault(),
                               IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                               NombreMuni = c.Select(v => v.NombreDepto).FirstOrDefault(),
                               IdDepto = c.Select(v => v.IdDepto).FirstOrDefault(),
                           }).ToList();
            }

            if (GrupoIn == "RECURSOS")
            {
                var ResultFindRECURSOS = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRecursos = ResultFindRECURSOS.Where(x => x.Tipo == "RECURSOS").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRecursos
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.SubTipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                var ResultMinisterio = ResultResoluciones
               .Where(x => x.NombreMuni == "MINISTERIO")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_N_1 == 31 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                var ResultSolicitante = ResultResoluciones
               .Where(x => x.NombreMuni == "SOLICITANTE")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_N_1 == 31 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                Result = ResultMinisterio.Union(ResultSolicitante).ToList();
            }

            if (GrupoIn == "CONSTANCIA DE EJECUTORIA")
            {
                var ResultFindCONSTANCIA = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultCONSTANCIA = ResultFindCONSTANCIA.Where(x => x.Tipo == "CONSTANCIA DE EJECUTORIA").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultCONSTANCIA
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   //Borrosos
                   Orden = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }

            if (GrupoIn == "RESOLUCION")
            {
                var ResultFindRESOLUCION = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRESOLUCION = ResultFindRESOLUCION.Where(x => x.Tipo == "RESOLUCION").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRESOLUCION
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   ////Borrosos
                   //Orden = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   //{ l, m }).Where(x => x.l.RESOLUCION_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                   //         .ToList()
                   //         .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // datos solicitante bien 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_DATOS_SOLICITANTE_BIEN == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }


            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ResumenListaDetalleNOTIFICACIONES(int IdDeptoIn, int IdCiudadIn, string GrupoIn)
        {
            string Id = IdDeptoIn + "_" + IdCiudadIn + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            List<CaracterizacionJuridicaResumenModel> Result = new List<CaracterizacionJuridicaResumenModel>();

            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());
            if (GrupoIn == "NOTIFICACIONES")
            {
                var ResultFind = processModel.Where(x => x.Tipo == GrupoIn && x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                Result = ResultFind
                           .GroupBy(z => z.SubTipo)
                           .Select(c => new CaracterizacionJuridicaResumenModel
                           {
                               Orden = c.Count(),
                               RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.SubTipo).FirstOrDefault(),
                               IdAspNetUser = c.Select(v => v.NombreMuni).FirstOrDefault(),
                               IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                               NombreMuni = c.Select(v => v.NombreDepto).FirstOrDefault(),
                               IdDepto = c.Select(v => v.IdDepto).FirstOrDefault(),
                           }).ToList();
            }

            if (GrupoIn == "RECURSOS")
            {
                var ResultFindRECURSOS = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRecursos = ResultFindRECURSOS.Where(x => x.Tipo == "RECURSOS").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRecursos
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.SubTipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                var ResultMinisterio = ResultResoluciones
               .Where(x => x.NombreMuni == "MINISTERIO")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_N_1 == 31 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                var ResultSolicitante = ResultResoluciones
               .Where(x => x.NombreMuni == "SOLICITANTE")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_N_1 == 31 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                Result = ResultMinisterio.Union(ResultSolicitante).ToList();
            }

            if (GrupoIn == "CONSTANCIA DE EJECUTORIA")
            {
                var ResultFindCONSTANCIA = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultCONSTANCIA = ResultFindCONSTANCIA.Where(x => x.Tipo == "CONSTANCIA DE EJECUTORIA").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultCONSTANCIA
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   //Borrosos
                   Orden = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }

            if (GrupoIn == "RESOLUCION")
            {
                var ResultFindRESOLUCION = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRESOLUCION = ResultFindRESOLUCION.Where(x => x.Tipo == "RESOLUCION").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRESOLUCION
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   ////Borrosos
                   //Orden = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   //{ l, m }).Where(x => x.l.RESOLUCION_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                   //         .ToList()
                   //         .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // datos solicitante bien 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_DATOS_SOLICITANTE_BIEN == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }


            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ResumenListaDetalleRESOLUCION(int IdDeptoIn, int IdCiudadIn, string GrupoIn)
        {
            string Id = IdDeptoIn + "_" + IdCiudadIn + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            List<CaracterizacionJuridicaResumenModel> Result = new List<CaracterizacionJuridicaResumenModel>();

            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());
            if (GrupoIn == "NOTIFICACIONES")
            {
                var ResultFind = processModel.Where(x => x.Tipo == GrupoIn && x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                Result = ResultFind
                           .GroupBy(z => z.SubTipo)
                           .Select(c => new CaracterizacionJuridicaResumenModel
                           {
                               Orden = c.Count(),
                               RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.SubTipo).FirstOrDefault(),
                               IdAspNetUser = c.Select(v => v.NombreMuni).FirstOrDefault(),
                               IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                               NombreMuni = c.Select(v => v.NombreDepto).FirstOrDefault(),
                               IdDepto = c.Select(v => v.IdDepto).FirstOrDefault(),
                           }).ToList();
            }

            if (GrupoIn == "RECURSOS")
            {
                var ResultFindRECURSOS = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRecursos = ResultFindRECURSOS.Where(x => x.Tipo == "RECURSOS").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRecursos
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.SubTipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                var ResultMinisterio = ResultResoluciones
               .Where(x => x.NombreMuni == "MINISTERIO")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_N_1 == 31 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                var ResultSolicitante = ResultResoluciones
               .Where(x => x.NombreMuni == "SOLICITANTE")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_N_1 == 31 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                Result = ResultMinisterio.Union(ResultSolicitante).ToList();
            }

            if (GrupoIn == "CONSTANCIA DE EJECUTORIA")
            {
                var ResultFindCONSTANCIA = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultCONSTANCIA = ResultFindCONSTANCIA.Where(x => x.Tipo == "CONSTANCIA DE EJECUTORIA").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultCONSTANCIA
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   //Borrosos
                   Orden = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }

            if (GrupoIn == "RESOLUCION")
            {
                var ResultFindRESOLUCION = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRESOLUCION = ResultFindRESOLUCION.Where(x => x.Tipo == "RESOLUCION").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRESOLUCION
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   ////Borrosos
                   //Orden = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   //{ l, m }).Where(x => x.l.RESOLUCION_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                   //         .ToList()
                   //         .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // datos solicitante bien 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_DATOS_SOLICITANTE_BIEN == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }


            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ResumenListaDetalleCONSTANCIA(int IdDeptoIn, int IdCiudadIn, string GrupoIn)
        {
            string Id = IdDeptoIn + "_" + IdCiudadIn + "_" + GetTokenObject().nameid;
            string Controller = "Administrator";
            string Method = "GetRegumenCaracterizacionJuridicaAll";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            List<CaracterizacionJuridicaResumenModel> Result = new List<CaracterizacionJuridicaResumenModel>();

            List<CaracterizacionJuridicaResumenModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionJuridicaResumenModel>>(jsonResult.ToString());
            if (GrupoIn == "NOTIFICACIONES")
            {
                var ResultFind = processModel.Where(x => x.Tipo == GrupoIn && x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                Result = ResultFind
                           .GroupBy(z => z.SubTipo)
                           .Select(c => new CaracterizacionJuridicaResumenModel
                           {
                               Orden = c.Count(),
                               RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.SubTipo).FirstOrDefault(),
                               IdAspNetUser = c.Select(v => v.NombreMuni).FirstOrDefault(),
                               IdMunicipio = c.Select(v => v.IdMunicipio.Value).FirstOrDefault(),
                               NombreMuni = c.Select(v => v.NombreDepto).FirstOrDefault(),
                               IdDepto = c.Select(v => v.IdDepto).FirstOrDefault(),
                           }).ToList();
            }

            if (GrupoIn == "RECURSOS")
            {
                var ResultFindRECURSOS = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRecursos = ResultFindRECURSOS.Where(x => x.Tipo == "RECURSOS").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRecursos
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.SubTipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                var ResultMinisterio = ResultResoluciones
               .Where(x => x.NombreMuni == "MINISTERIO")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_N_1 == 31 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "MINISTERIO"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                var ResultSolicitante = ResultResoluciones
               .Where(x => x.NombreMuni == "SOLICITANTE")
               .GroupBy(c => c.NombreMuni)
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.Select(v => v.NombreMuni).FirstOrDefault(),

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault(),

                   //sin respuesta 
                   Orden = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 == false && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //no procede 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_N_1 == 31 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 14 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // Niega 
                   IdMunicipio = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 15 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   // pruebas     
                   CONSTANCIA_DE_EJECUTORIA_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 16 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   //revoca
                   SOLICITUD_VISIBLE = ResultRecursos.Join(ResultFindRECURSOS, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 == 33 && x.l.SubTipo == "SOLICITANTE"
                   && x.l.RESOLUCION_DECISION_78 == c.Select(v => v.INSPECCION_OCULAR_VISIBLE).FirstOrDefault())
                            .ToList()
                            .Count(),

                   Gestion = c.Count()
               }).ToList();

                Result = ResultMinisterio.Union(ResultSolicitante).ToList();
            }

            if (GrupoIn == "CONSTANCIA DE EJECUTORIA")
            {
                var ResultFindCONSTANCIA = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultCONSTANCIA = ResultFindCONSTANCIA.Where(x => x.Tipo == "CONSTANCIA DE EJECUTORIA").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultCONSTANCIA
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   //Borrosos
                   Orden = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // adjudica 
                   RECURSO_SOLICITANTE_VISIBLE = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultCONSTANCIA.Join(ResultFindCONSTANCIA, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }

            if (GrupoIn == "RESOLUCION")
            {
                var ResultFindRESOLUCION = processModel.Where(x => x.IdMunicipio == IdCiudadIn && x.IdDepto == IdDeptoIn.ToString()).ToList();
                var ResultRESOLUCION = ResultFindRESOLUCION.Where(x => x.Tipo == "RESOLUCION").ToList();

                List<CaracterizacionJuridicaResumenModel> ResultResoluciones = ResultRESOLUCION
                .GroupBy(c => c.RESOLUCION_DECISION_78)
                .Select(c => new CaracterizacionJuridicaResumenModel
                {
                    INSPECCION_OCULAR_VISIBLE = c.Select(v => v.RESOLUCION_DECISION_78).FirstOrDefault(),// resolucion,
                    NombreMuni = c.Select(v => v.Tipo).FirstOrDefault(),// Tipo de recurso,
                    SOLICITUD_VISIBLE = c.Select(v => v.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92).FirstOrDefault(),// resolucion
                    Gestion = c.Count()
                }).ToList();

                Result = ResultResoluciones
               .Select(c => new CaracterizacionJuridicaResumenModel
               {
                   // Tipo
                   RECURSO_SOLICITANTE_NUMERO_90 = c.NombreMuni,

                   // Resoulicion
                   INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,

                   ////Borrosos
                   //Orden = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   //{ l, m }).Where(x => x.l.RESOLUCION_VISIBLE.Value == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                   //         .ToList()
                   //         .Count(),

                   //Sin firma 
                   RECURSO_SOLICITANTE_ACTO_89 = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == false && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // datos solicitante bien 
                   RECURSO_SOLICITANTE_VISIBLE = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_DATOS_SOLICITANTE_BIEN == 2 && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),

                   // con firma 
                   IdMunicipio = ResultRESOLUCION.Join(ResultFindRESOLUCION, l => l.Id, m => m.Id, (l, m) => new
                   { l, m }).Where(x => x.l.RESOLUCION_FIRMADA_77 == true && x.l.Tipo == c.NombreMuni && x.l.RESOLUCION_DECISION_78 == c.INSPECCION_OCULAR_VISIBLE)
                            .ToList()
                            .Count(),
                   Gestion = c.Gestion,

               }).ToList();
            }


            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResumenIndex(int IdDeptoIn, int IdCiudadIn)
        {
            return Json(new { result = "Redirect", url = Url.Action("Resumen", "CaracterizacionJuridicaResumen", new { IdDepto = IdDeptoIn, IdCiudad = IdCiudadIn }) });
        }

        public ActionResult Index()
        {
            return View();

        }

    }
}