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
    public class Ba_MemorandoController : BaseController
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
            string Controller = "Ba_Memorando";
            string Method = "getBa_MemorandoCatalogoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<Ba_MemorandoCatalogosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ba_MemorandoCatalogosModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {

            string Id = GetTokenObject().nameid;
            string Controller = "Ba_Memorando";
            string Method = "getBa_Memorando";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<Ba_MemorandoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ba_MemorandoModel>>(jsonResult.ToString());
            return View(processModel);

        }

        public ActionResult Crear()
        {
            Ba_MemorandoModel Ba_MemorandoModel_ = new Ba_MemorandoModel();
            string Id = GetTokenObject().nameid;
            Ba_MemorandoModel_.IdAspNetUser = Id;
            Ba_MemorandoModel_.IdAspNetUserModifica = Id;
            Ba_MemorandoModel_.rol = GetTokenObject().role;
            Ba_MemorandoModel_.NombreIdAspNetUser = GetTokenObject().FullName;

            return View(Ba_MemorandoModel_);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Ba_MemorandoModel ObjData)
        {
           
            string Id = GetTokenObject().nameid;
            ObjData.IdAspNetUser = Id;
            ObjData.IdAspNetUserModifica = Id;
            string Controller = "Ba_Memorando";
            string Method = "Ba_Memorandocreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    Ba_MemorandoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_MemorandoModel>(jsonResult.ToString());
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
            string Controller = "Ba_Memorando";
            string Method = "getBa_Memorandoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            Ba_MemorandoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_MemorandoModel>(jsonResult.ToString());
            processModel.Gestion = 1; 
            processModel.FechaModificacion = DateTime.Now;
            processModel.IdAspNetUserModifica = GetTokenObject().nameid;
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Ba_MemorandoModel ObjData)
        {
            ObjData.Estado = 1;
            string Id = GetTokenObject().nameid;
            string Controller = "Ba_Memorando";
            string Method = "Ba_Memorandoupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    Ba_MemorandoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_MemorandoModel>(jsonResult.ToString());
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
            string Controller = "Ba_Memorando";
            string Method = "getBa_Memorando";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<Ba_MemorandoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ba_MemorandoModel>>(jsonResult.ToString());
           
            var Validacion4 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion28)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion28.ToString()).FirstOrDefault(),
                                      Tipo = "DEPARTAMENTO",
                                  }).ToList();

            var Validacion5 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion29)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion29.ToString()).FirstOrDefault(),
                                      Tipo = "MUNICIPIO",
                                  }).ToList();

            var Validacion8 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion8)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion8.ToString()).FirstOrDefault(),
                                      Tipo = "TIPO SOLICITUD",
                                  }).ToList();

            var Validacion11 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion11)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion11.ToString()).FirstOrDefault(),
                                      Tipo = "COPIA DOCUMENTOS SOLICITANTE Y CONYUGE CARGADOS",
                                  }).ToList();


            var Validacion12 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion12)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion12.ToString()).FirstOrDefault(),
                                      Tipo = "SI TIENE CERTIFICADO REPORTADO EN EL MEMO QUE SE ENCUENTRE CARGADO",
                                  }).ToList();


            var Validacion13 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion13)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion13.ToString()).FirstOrDefault(),
                                      Tipo = "DECLARA RENTA SOLICITANTE",
                                  }).ToList();


            var Validacion14 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion14)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion14.ToString()).FirstOrDefault(),
                                      Tipo = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS SOLICITANTE",
                                  }).ToList();


            var Validacion15 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion15)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion15.ToString()).FirstOrDefault(),
                                      Tipo = "PROPIETARIO DE OTRO PREDIO SOLICITANTE",
                                  }).ToList();


            var Validacion16 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion16)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion16.ToString()).FirstOrDefault(),
                                      Tipo = "PRESENTA PENDIENTES JUDICIALES SOLICITANTE",
                                  }).ToList();


            var Validacion17 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion17)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion17.ToString()).FirstOrDefault(),
                                      Tipo = "OCUPANTE INDEBIDO SOLICITANTE",
                                  }).ToList();


            var Validacion18 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion18)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion18.ToString()).FirstOrDefault(),
                                      Tipo = "VICTIMA DEL CONFLICTO ARMADO SOLICITANTE",
                                  }).ToList();



            var Validacion21 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion21)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion21.ToString()).FirstOrDefault(),
                                      Tipo = "DECLARA RENTA CONYUGE",
                                  }).ToList();


            var Validacion22 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion22)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion22.ToString()).FirstOrDefault(),
                                      Tipo = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS CONYUGE",
                                  }).ToList();


            var Validacion23 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion23)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion23.ToString()).FirstOrDefault(),
                                      Tipo = "PROPIETARIO DE OTRO PREDIO CONYUGE",
                                  }).ToList();


            var Validacion24 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion24)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion24.ToString()).FirstOrDefault(),
                                      Tipo = "PRESENTA PENDIENTES JUDICIALES CONYUGE",
                                  }).ToList();


            var Validacion25 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion25)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion25.ToString()).FirstOrDefault(),
                                      Tipo = "OCUPANTE INDEBIDO CONYUGE",
                                  }).ToList();


            var Validacion26 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion26)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion26.ToString()).FirstOrDefault(),
                                      Tipo = "VICTIMA DEL CONFLICTO ARMADO CONYUGE",
                                  }).ToList();


            var Validacion27 = processModel
                                .Select(x => x)
                                .GroupBy(z => z.Validacion27)
                                  .Select(c => new
                                  {
                                      Total = c.Count(),
                                      Grupo = c.Select(v => v.Validacion27.ToString()).FirstOrDefault(),
                                      Tipo = "INCLUSION RESO",
                                  }).ToList();

            Validacion4.AddRange(Validacion5);
            Validacion4.AddRange(Validacion8);
            Validacion4.AddRange(Validacion11);
            Validacion4.AddRange(Validacion12);
            Validacion4.AddRange(Validacion13);
            Validacion4.AddRange(Validacion14);
            Validacion4.AddRange(Validacion15);
            Validacion4.AddRange(Validacion16);
            Validacion4.AddRange(Validacion17);
            Validacion4.AddRange(Validacion18);
            Validacion4.AddRange(Validacion21);
            Validacion4.AddRange(Validacion22);
            Validacion4.AddRange(Validacion23);
            Validacion4.AddRange(Validacion24);
            Validacion4.AddRange(Validacion25);
            Validacion4.AddRange(Validacion26);
            Validacion4.AddRange(Validacion27);

            return Json(Validacion4, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ba_Memorando";
            string Method = "getBa_MemorandoidExp";
            string result = await employeeProvider.Get(Id, Controller, Method);

            Ba_MemorandoModel processModel = new Ba_MemorandoModel();
            if (result != null)
            {
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_MemorandoModel>(jsonResult.ToString());
            }

            return View(processModel);

        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ba_Memorando";
            string Method = "getBa_Memorandoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            Ba_MemorandoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ba_MemorandoModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Ba_MemorandoModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ba_Memorando";
            string Method = "getBa_Memorandodelete";
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