using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Configuration;

using ExcelDataReader;
using System.Data;
using System.IO;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class BaldiosPersonaNaturalController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> BuscaArchivos(int IdTable)  // --------------------- //

        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalBuscarArchivos";
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
                return Json("ok");
            }
        }
        public async Task<ActionResult>  ListDepto()
        {
            string Id = "0";
            string Controller = "hvctDepto";
            string Method = "gethvctDepto";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());
        }

        public async Task<ActionResult> ListDeptoId(string IdP)
        {
            string Controller = "hvctDepto";
            string Method = "gethvctdepto";
            string result = await employeeProvider.Get(IdP, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());

        }

        public async Task<ActionResult> ListPais()
        {
            string Id = "0";
            string Controller = "hvctpais";
            string Method = "gethvctpais";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CtPaisModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> ListRetencionDocumentalGrupo()
        {
            string Id = "0";
            string Controller = "RetencionDocumentalGrupo";
            string Method = "getRetencionDocumentalGrupo";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RetencionDocumentalGrupoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RetencionDocumentalGrupoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NombreGrupo, Value = x.Id.ToString() }).ToList());
        }

        public async Task<ActionResult> ListRetencionDocumental(int Id)
        {
            string Controller = "RetencionDocumental";
            string Method = "getRetencionDocumentalGrupo";
            string result = await employeeProvider.Get(Id.ToString(), Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RetencionDocumentalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RetencionDocumentalModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() }).ToList());
        }

        public async Task<JsonResult> ListExpedienteDocumentos(int Id)
        {
            string Controller = "ExpedienteDocumentos";
            string Method = "getExpedienteDocumentosIdExpediente";
            string result = await employeeProvider.Get(Id.ToString(), Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ExpedienteDocumentosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExpedienteDocumentosModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> ListExpedienteDocumentosByIdDoc(string Id)
        {   
            string Controller = "ExpedienteDocumentos";
            string Method = "getExpedienteDocumentosIdExpedienteIdDoc";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ExpedienteDocumentosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExpedienteDocumentosModel>>(jsonResult.ToString());
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> PostExpedienteDocumentos(int EstadoExp , int EstadoExpUser,  int IdRetencionDocumental,int IdExpediente, int PagInicial, int PagFinal, string ArchivoActual, string ArchivoActualUrl)
        {
            // EstadoExp 
            // true = verificado
            // false = no verificado 

            ExpedienteDocumentosModel ObjData = new ExpedienteDocumentosModel();
            ObjData.Id = 0;
            ObjData.IdRetencionDocumental = IdRetencionDocumental;
            ObjData.NombreRetencionDocumental = "NA";
            ObjData.IdExpediente = IdExpediente;
            ObjData.NombreExpediente = "NA";
            ObjData.PagInicial = PagInicial;
            ObjData.PagFinal = PagFinal;
            ObjData.Archivo = ArchivoActual;
            ObjData.ArchivoUrl = ArchivoActualUrl;
            if (EstadoExpUser == 1) { ObjData.Estado = true; } else { ObjData.Estado = false; }
            ObjData.EstadoExp = EstadoExp;
            ObjData.FechaInserta = DateTime.Now.ToString();
            ObjData.FechaModifica = DateTime.Now.ToString();
            ObjData.UsuarioInserta = GetTokenObject().nameid;
            ObjData.UsuarioModifica = GetTokenObject().nameid;
            string Controller = "ExpedienteDocumentos";
            string Method = "ExpedienteDocumentoscreate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    ExpedienteDocumentosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpedienteDocumentosModel>(jsonResult.ToString());
                    if (processModel.UsuarioModifica.Equals(""))
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

        public async Task<JsonResult> PostUpdateStatus(int TypeMetodo, int Id, string ValueMe)
        {
            // EstadoExp 
            // true = verificado
            // false = no verificado 

            CtGeneroModel ObjData = new CtGeneroModel();
            ObjData.ID_GENERO = Id;
            ObjData.NOMBRE = ValueMe;
            string Controller = "BaldiosPersonaNatural";
            string Method = "";
            if (TypeMetodo == 1 )
            {
                Method = "BaldiosPersonaNaturalUpdateArchivoVerificado";
            }
            else {
                Method = "BaldiosPersonaNaturalUpdateEstatusCaracterizacion";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    CtGeneroModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CtGeneroModel>(jsonResult.ToString());
                    if (processModel.NOMBRE.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        return Json("OK");
                    }
                }
                catch (InvalidCastException e)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator." + e);
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


        public async Task<JsonResult> DeleteExpedienteDocumentos(int IdDoc)
        {
            string processModel = "";
            try {
                string Id = IdDoc.ToString();
                string Controller = "ExpedienteDocumentos";
                string Method = "getExpedienteDocumentosdelete";
                string result = await employeeProvider.Delete(Controller, Method, Id);
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                processModel = jsonResult.ToString();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error reading from {0}. Message = {1}",  e.Message);
            }

            // string Controller, string Method, string Id
            return Json(new { Resultado = processModel }, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> Index()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNatural";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> IndexUser()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalUser";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> IndexUserMal()
        {
            string Id = GetTokenObject().nameid;
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalUserMal";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return View("IndexUser", processModel);
        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(BaldiosPersonaNaturalModel ObjData)
        {
            string Controller = "BaldiosPersonaNatural";
            string Method = "BaldiosPersonaNaturalcreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
                    if (processModel.NumeroExpediente.Equals(""))
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

        public ActionResult CrearExcel()
        {
            CrearBaldiosExcelMvcModel Modelo = new CrearBaldiosExcelMvcModel();
            return View(Modelo);
        }

        [HttpPost]
        public async Task<ActionResult> CrearExcel(CrearBaldiosExcelMvcModel Modelo)
        {
            string Controller = "BaldiosPersonaNatural";
            string Method = "BaldiosPersonaNaturalcreate";

            var fileName = Path.GetFileName(Modelo.Soporte.FileName);
            var path = Path.Combine("C:\\ReportAnt\\", "Leer" + fileName);
            string ruta = @"" + ConfigurationManager.AppSettings["PdfPath"]; // RUTA DE LOS ARCHIVOS

            Modelo.Soporte.SaveAs(path);

            using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
            {

                IExcelDataReader excelDataReader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

                var conf = new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = a => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                DataSet dataSet = excelDataReader.AsDataSet(conf);
                DataRowCollection row = dataSet.Tables["Nuevos"].Rows;

                if (row.Count == 0)
                {
                    Modelo.Errores = "El Excel no contiene filas";
                   // return View(Modelo);
                }
                else {
                    List<object> rowDataList = null;
                    int i = 0;
                    bool Valid = false;
                    string Errores = "";
                    foreach (DataRow itemExcel in row)
                    {
                        rowDataList = itemExcel.ItemArray.ToList(); //list of each rows
                        i++;
                        Errores = Errores + "Fila :" + i + "<br>";

                        BaldiosPersonaNaturalModel ObjData = new BaldiosPersonaNaturalModel();

                        if (rowDataList[0] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Numero Expediente : No puede estar en blanco" + "<br>";
                        }
                        else {
                            ObjData.NumeroExpediente = rowDataList[0].ToString();
                        }

                        if (rowDataList[1] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Departamento : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.IdDepto = Convert.ToInt64(rowDataList[1]);
                        }

                        if (rowDataList[2] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Municipio : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.IdCiudad = Convert.ToInt64(rowDataList[2]);
                        }

                        if (rowDataList[3] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Vereda : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.Vereda = rowDataList[3].ToString();
                        }

                        if (rowDataList[4] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Nombre Predio : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.NombrePredio = rowDataList[4].ToString();
                        }

                        if (rowDataList[5] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Nombre Beneficiario : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.NombreBeneficiario = rowDataList[5].ToString(); ;
                        }

                        if (rowDataList[6] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Tipo Identificacion : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.IdTipoIdentificacion = Convert.ToInt32(rowDataList[6]);
                        }

                        if (rowDataList[7] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Identificacion : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.Identificacion = rowDataList[7].ToString();
                        }

                        if (rowDataList[8] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "El Genero : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.IdGenero = Convert.ToInt32(rowDataList[8]);
                        }

                        if (rowDataList[9] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Tipo Identificacion Conyuge : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.IdTipoIdentificacionConyuge = Convert.ToInt32(rowDataList[9]);
                        }

                        if (rowDataList[10] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Identificacion Conyuge : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.IdentificacionConyuge = rowDataList[10].ToString();
                        }

                        if (rowDataList[11] == System.DBNull.Value)
                        {
                            Valid = true;
                            Errores = Errores + "Identificacion Conyuge : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            ObjData.NombreConyuge = rowDataList[11].ToString();
                        }

                        String rutaFullDepto = ruta + "/Deptos/" + ObjData.IdDepto + "/";
                        String rutaFullMuni = rutaFullDepto + "/" + ObjData.IdCiudad;

                        if (!Directory.Exists(rutaFullDepto)) // verificamos si el directorio de departamentos existe
                        {
                            Directory.CreateDirectory(rutaFullDepto);
                            if (!Directory.Exists(rutaFullMuni)) // verificamos si el directorio de departamentos existe
                            {
                                Directory.CreateDirectory(rutaFullMuni);
                            }
                        }
                        else {
                            if (!Directory.Exists(rutaFullMuni)) // verificamos si el directorio de departamentos existe
                            {
                                Directory.CreateDirectory(rutaFullMuni);
                            }
                        }

                        try
                        {
                            System.IO.File.Copy(rowDataList[13].ToString()+"/"+rowDataList[14].ToString(), rutaFullMuni + "/" + rowDataList[14].ToString());
                        }
                        catch (IOException copyError)
                        {
                            Console.WriteLine(copyError.Message);
                        }
                        ObjData.RutaArchivoOriginal = rutaFullMuni + "/" + rowDataList[14].ToString();
                        ObjData.NombreArchivo = rowDataList[14].ToString();


                        ObjData.NombreIdTipoIdentificacionConyuge = "N_A";
                        ObjData.NombreIdTipoIdentificacion = "N_A";
                        ObjData.NombreIdGenero = "N_A";
                        ObjData.NombreIdDepto = "N_A";
                        ObjData.NombreIdCiudad = "N_A";
                        ObjData.EstadoInicialMigracion = "N_A";
                        ObjData.IdAspNetUser = "N_A";
                        ObjData.NombreIdAspNetUser = "N_A";
                        ObjData.EstadoCaracterizacion = false;
                        ObjData.TipoArchivo = "N_A";
                        ObjData.NombreUsuario = "N_A";
                        ObjData.RolUsuario = "N_A";
                        ObjData.IdUsuario = "N_A";
                        ObjData.Grupo = "N_A";

                        if (Valid == true)
                        {
                           // return View(Modelo);
                        }
                        else {
                            Errores = Errores + "Sin errores <br>";
                            try
                            {
                                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                                DictionaryModel ObjDictionary = new DictionaryModel();
                                keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                                string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                                BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
                                if (processModel.NumeroExpediente.Equals(""))
                                {
                                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                                    return View(ModelState);
                                }
                            }
                            catch
                            {
                                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                                return View(ModelState);
                            }
                        }
                    }
                    Modelo.Errores = Errores;
                }
            }
            Modelo.Status = "Se crearon los expedientes, valide los registros que presentan error ";
            return View(Modelo);
        }

       
        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(BaldiosPersonaNaturalModel ObjData)
        {
            string Controller = "BaldiosPersonaNatural";
            string Method = "BaldiosPersonaNaturalupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
                    if (processModel.NumeroExpediente.Equals(""))
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
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturalid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            BaldiosPersonaNaturalModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BaldiosPersonaNaturalModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(BaldiosPersonaNaturalModel ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "BaldiosPersonaNatural";
            string Method = "getBaldiosPersonaNaturaldelete";
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