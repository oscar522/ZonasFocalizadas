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
    public class CaracterizacionAgronomicaController : BaseController
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
            string Controller = "CaracterizacionAgronomica";
            string Method = "getCaracterizacionAgronomicaCatalogoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionAgronomicaCatalogosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionAgronomicaCatalogosModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {

            string Id = GetTokenObject().nameid;
            string Controller = "CaracterizacionAgronomica";
            string Method = "getCaracterizacionAgronomica";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View(processModel);

        }

        public ActionResult Crear()
        {
            CaracterizacionAgronomicaModel CaracterizacionAgronomicaModel_ = new CaracterizacionAgronomicaModel();
            string Id = GetTokenObject().nameid;
            CaracterizacionAgronomicaModel_.IdAspNetUser = Id;
            CaracterizacionAgronomicaModel_.IdAspNetUserModifica = Id;
            return View(CaracterizacionAgronomicaModel_);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CaracterizacionAgronomicaModel ObjData)
        {
           
            string Id = GetTokenObject().nameid;
            ObjData.IdAspNetUser = Id;
            ObjData.IdAspNetUserModifica = Id;
            string Controller = "CaracterizacionAgronomica";
            string Method = "CaracterizacionAgronomicacreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    CaracterizacionAgronomicaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionAgronomicaModel>(jsonResult.ToString());
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
            string Controller = "CaracterizacionAgronomica";
            string Method = "getCaracterizacionAgronomicaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            CaracterizacionAgronomicaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionAgronomicaModel>(jsonResult.ToString());
            processModel.Gestion = 1; 
            processModel.FechaModificacion = DateTime.Now;
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CaracterizacionAgronomicaModel ObjData)
        {
            ObjData.Estado = 1;
            string Id = GetTokenObject().nameid;
             string Controller = "CaracterizacionAgronomica";
            string Method = "CaracterizacionAgronomicaupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    CaracterizacionAgronomicaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionAgronomicaModel>(jsonResult.ToString());
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

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CaracterizacionAgronomica";
            string Method = "getCaracterizacionAgronomicaidExp";
            string result = await employeeProvider.Get(Id, Controller, Method);

            CaracterizacionAgronomicaModel processModel = new CaracterizacionAgronomicaModel();
            if (result != null)
            {
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionAgronomicaModel>(jsonResult.ToString());
            }

            return View(processModel);

        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CaracterizacionAgronomica";
            string Method = "getCaracterizacionAgronomicaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            CaracterizacionAgronomicaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CaracterizacionAgronomicaModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(CaracterizacionAgronomicaModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CaracterizacionAgronomica";
            string Method = "getCaracterizacionAgronomicadelete";
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