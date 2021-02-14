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
    public class Ba_Memorando_newController : BaseController
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

        public async Task<ActionResult> ListTipos(string Id)
        {
            string Controller = "Ba_Memorando_new";
            string Method = "getBa_Memorando_newCatalogoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<Ba_MemorandoCatalogosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ba_MemorandoCatalogosModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {

            string Id = GetTokenObject().nameid;
            string Controller = "Ba_Memorando_new";
            string Method = "getBa_Memorando_new";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<Ba_Memorando_newModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ba_Memorando_newModel>>(jsonResult.ToString());
            return View(processModel);

        }

        public ActionResult Crear()
        {
            Ba_Memorando_newModel Ba_Memorando_newModel_ = new Ba_Memorando_newModel();
            string Id = GetTokenObject().nameid;
            Ba_Memorando_newModel_.IdAspNetUser = Id;
            Ba_Memorando_newModel_.IdAspNetUserModifica = Id;
            Ba_Memorando_newModel_.rol = GetTokenObject().role;
            Ba_Memorando_newModel_.NombreIdAspNetUser = GetTokenObject().FullName;

            return View(Ba_Memorando_newModel_);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Ba_Memorando_newModel ObjData)
        {
           
            string Id = GetTokenObject().nameid;
            ObjData.IdAspNetUser = Id;
            ObjData.IdAspNetUserModifica = Id;
            string Controller = "Ba_Memorando_new";
            string Method = "Ba_Memorando_newcreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    Ba_Memorando_newModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_Memorando_newModel>(jsonResult.ToString());
                    if (processModel.Id == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(ObjData);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(ObjData);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Todos los campos requeridos ");
                return View(ObjData);
            }
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ba_Memorando_new";
            string Method = "getBa_Memorando_newid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            Ba_Memorando_newModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_Memorando_newModel>(jsonResult.ToString());
            processModel.Gestion = 1; 
            processModel.FechaModificacion = DateTime.Now;
            processModel.IdAspNetUserModifica = GetTokenObject().nameid;
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Ba_Memorando_newModel ObjData)
        {
            ObjData.Estado = 1;
            string Id = GetTokenObject().nameid;
            string Controller = "Ba_Memorando_new";
            string Method = "Ba_Memorando_newupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    Ba_Memorando_newModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_Memorando_newModel>(jsonResult.ToString());
                    if (processModel.Id == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(ObjData);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(ObjData);  
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Todos los campos requeridos ");
                return View(ObjData);
            }
        }

        public async Task<ActionResult> GetAll()
        {
            string Id = "0";
            string Controller = "Ba_Memorando_new";
            string Method = "getBa_Memorando_new";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<Ba_Memorando_newModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ba_Memorando_newModel>>(jsonResult.ToString());

            ///// DATA GENERAL 
            var cargaorfeo_ = processModel
                .Select(x => x)
                .GroupBy(z => z.cargaorfeo)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.cargaorfeo.ToString()).FirstOrDefault(),
                    Tipo = "CARGA ORFEO"
                }).ToList();


            var asignado_ = processModel
                .Select(x => x)
                .GroupBy(z => z.asignado)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.asignado.ToString()).FirstOrDefault(),
                    Tipo = "ASIGNADO"
                }).ToList();

            var tiposolicitud_ = processModel
              .Select(x => x)
              .GroupBy(z => z.tiposolicitud)
              .Select(c => new
              {
                  Total = c.Count(),
                  Grupo = c.Select(v => v.tiposolicitud.ToString()).FirstOrDefault(),
                  Tipo = "TIPO SOLICITUD"
              }).ToList();

            var copiadoc_ = processModel
                .Select(x => x)
                .GroupBy(z => z.copiadoc)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.copiadoc.ToString()).FirstOrDefault(),
                    Tipo = "COPIA DOCUMENTOS SOLICITANTE Y CONYUGE CARGADOS"
                }).ToList();


            var copiacertificadocurso_ = processModel
                .Select(x => x)
                .GroupBy(z => z.copiacertificadocurso)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.copiacertificadocurso.ToString()).FirstOrDefault(),
                    Tipo = "COPIA DE CURSO AGRONOMICO ENUNCIADO EN EL MEMORANDO"
                }).ToList();

            //// UBICACION
            var municipio_ = processModel
                .Select(x => x)
                .GroupBy(z => z.municipio)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.municipio.ToString()).FirstOrDefault(),
                    Tipo = "MUNICIPIO"
                }).ToList();


            var departamento_ = processModel
                .Select(x => x)
                .GroupBy(z => z.departamento)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.departamento.ToString()).FirstOrDefault(),
                    Tipo = "DEPARTAMENTO"
                }).ToList();


          

          
            ///// SOLICITANTE
            
            var declararentasol_ = processModel
                .Select(x => x)
                .GroupBy(z => z.declararentasol)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.declararentasol.ToString()).FirstOrDefault(),
                    Tipo = "DECLARA RENTA SOLICITANTE"
                }).ToList();


            var beneficiariosol_ = processModel
                .Select(x => x)
                .GroupBy(z => z.beneficiariosol)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.beneficiariosol.ToString()).FirstOrDefault(),
                    Tipo = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS SOLICITANTE"
                }).ToList();


            var propietariosol_ = processModel
                .Select(x => x)
                .GroupBy(z => z.propietariosol)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.propietariosol.ToString()).FirstOrDefault(),
                    Tipo = "PROPIETARIO DE OTRO PREDIO SOLICITANTE"
                }).ToList();


            var penjudicialessol_ = processModel
                .Select(x => x)
                .GroupBy(z => z.penjudicialessol)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.penjudicialessol.ToString()).FirstOrDefault(),
                    Tipo = "PRESENTA PENDIENTES JUDICIALES SOLICITANTE"
                }).ToList();


            var ocupanteindebidosol_ = processModel
                .Select(x => x)
                .GroupBy(z => z.ocupanteindebidosol)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.ocupanteindebidosol.ToString()).FirstOrDefault(),
                    Tipo = "OCUPANTE INDEBIDO SOLICITANTE"
                }).ToList();


            var victimadsol_ = processModel
                .Select(x => x)
                .GroupBy(z => z.victimadsol)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.victimadsol.ToString()).FirstOrDefault(),
                    Tipo = "VICTIMA DEL CONFLICTO ARMADO SOLICITANTE"
                }).ToList();

            //// CONYUGE
           
            var declararentacony_ = processModel
                .Select(x => x)
                .GroupBy(z => z.declararentacony)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.declararentacony.ToString()).FirstOrDefault(),
                    Tipo = "DECLARA RENTA CONYUGE"
                }).ToList();


            var beneficiariocony_ = processModel
                .Select(x => x)
                .GroupBy(z => z.beneficiariocony)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.beneficiariocony.ToString()).FirstOrDefault(),
                    Tipo = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS CONYUGE"
                }).ToList();


            var propietariocony_ = processModel
                .Select(x => x)
                .GroupBy(z => z.propietariocony)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.propietariocony.ToString()).FirstOrDefault(),
                    Tipo = "PROPIETARIO DE OTRO PREDIO CONYUGE"
                }).ToList();


            var penjudicialescony_ = processModel
                .Select(x => x)
                .GroupBy(z => z.penjudicialescony)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.penjudicialescony.ToString()).FirstOrDefault(),
                    Tipo = "PRESENTA PENDIENTES JUDICIALES CONYUGE"
                }).ToList();


            var ocupanteindevidocony_ = processModel
                .Select(x => x)
                .GroupBy(z => z.ocupanteindevidocony)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.ocupanteindevidocony.ToString()).FirstOrDefault(),
                    Tipo = "OCUPANTE INDEBIDO CONYUGE"
                }).ToList();


            var victimadcony_ = processModel
                .Select(x => x)
                .GroupBy(z => z.victimadcony)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.victimadcony.ToString()).FirstOrDefault(),
                    Tipo = "VICTIMA DEL CONFLICTO ARMADO CONYUGE"
                }).ToList();


            var inclusionreso_ = processModel
                .Select(x => x)
                .GroupBy(z => z.inclusionreso)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.inclusionreso.ToString()).FirstOrDefault(),
                    Tipo = "INCLUSIÓN RESO"
                }).ToList();


            var respojuridico_ = processModel
                .Select(x => x)
                .GroupBy(z => z.respojuridico)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.respojuridico.ToString()).FirstOrDefault(),
                    Tipo = "RESPOSABLE JURIDICO"
                }).ToList();


            var respoagronomo_ = processModel
                .Select(x => x)
                .GroupBy(z => z.respoagronomo)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.respoagronomo.ToString()).FirstOrDefault(),
                    Tipo = "RESPOSABLE AGRONOMO"
                }).ToList();


            var respocatastral_ = processModel
                .Select(x => x)
                .GroupBy(z => z.respocatastral)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.respocatastral.ToString()).FirstOrDefault(),
                    Tipo = "RESPOSABLE CATASTRAL"
                }).ToList();


            var responsable_ = processModel
                .Select(x => x)
                .GroupBy(z => z.responsable)
                .Select(c => new
                {
                    Total = c.Count(),
                    Grupo = c.Select(v => v.responsable.ToString()).FirstOrDefault(),
                    Tipo = "RESPOSABLE"
                }).ToList();




            cargaorfeo_.AddRange(asignado_);
            cargaorfeo_.AddRange(municipio_);
            cargaorfeo_.AddRange(departamento_);
            cargaorfeo_.AddRange(tiposolicitud_);
            cargaorfeo_.AddRange(copiadoc_);
            cargaorfeo_.AddRange(copiacertificadocurso_);
            cargaorfeo_.AddRange(declararentasol_);
            cargaorfeo_.AddRange(beneficiariosol_);
            cargaorfeo_.AddRange(propietariosol_);
            cargaorfeo_.AddRange(penjudicialessol_);
            cargaorfeo_.AddRange(ocupanteindebidosol_);
            cargaorfeo_.AddRange(victimadsol_);
            cargaorfeo_.AddRange(declararentacony_);
            cargaorfeo_.AddRange(beneficiariocony_);
            cargaorfeo_.AddRange(propietariocony_);
            cargaorfeo_.AddRange(penjudicialescony_);
            cargaorfeo_.AddRange(ocupanteindevidocony_);
            cargaorfeo_.AddRange(victimadcony_);
            cargaorfeo_.AddRange(inclusionreso_);
            cargaorfeo_.AddRange(respojuridico_);
            cargaorfeo_.AddRange(respoagronomo_);
            cargaorfeo_.AddRange(respocatastral_);
            cargaorfeo_.AddRange(responsable_);


            return Json(cargaorfeo_, JsonRequestBehavior.AllowGet);
            //return Json("", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ba_Memorando_new";
            string Method = "getBa_Memorando_newidExp";
            string result = await employeeProvider.Get(Id, Controller, Method);

            Ba_Memorando_newModel processModel = new Ba_Memorando_newModel();
            if (result != null)
            {
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_Memorando_newModel>(jsonResult.ToString());
            }

            return View(processModel);

        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ba_Memorando_new";
            string Method = "getBa_Memorando_newid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            Ba_Memorando_newModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_Memorando_newModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Ba_Memorando_newModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ba_Memorando_new";
            string Method = "getBa_Memorando_newdelete";
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