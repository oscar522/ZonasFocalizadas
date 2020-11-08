using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Linq;
using System.IO;
using System.Configuration;
using ExcelDataReader;
using System.Data;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    //[Authorize]
    public class AsignacionController : WebClientAdmin.BaseController
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

       
        public async Task<ActionResult>Registro()
        {
            string Id = "0";
            string Controller = "Reportes";
            string Method = "getRegistro";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            string processModel = jsonResult.ToString();
            return new JsonResult()
            {
                Data = processModel,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> Juridica()
        {
            string Id = "0";
            string Controller = "Reportes";
            string Method = "getJuridica";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            string processModel = jsonResult.ToString();
            return new JsonResult()
            {
                Data = processModel,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> Solicitante()
        {
            string Id = "0";
            string Controller = "Reportes";
            string Method = "getSolicitante";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            string processModel = jsonResult.ToString();
            return new JsonResult()
            {
                Data = processModel,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public ActionResult Index()
        {
            CrearBaldiosExcelMvcModel Modelo = new CrearBaldiosExcelMvcModel();
            return View(Modelo);
        }

        public async Task<ActionResult> CrearExcel(CrearBaldiosExcelMvcModel Modelo)
        {
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
                }
                else
                {
                    List<object> rowDataList = null;
                    int i = 0;
                    string Errores = "";
                    foreach (DataRow itemExcel in row)
                    {
                        rowDataList = itemExcel.ItemArray.ToList(); //list of each rows
                        i++;
                        Errores = Errores + "Fila :" + i + "<br>";
                        string NumeroExpediente = "";

                        if (rowDataList[0] == System.DBNull.Value)
                        {
                            Errores = Errores + "Numero Expediente : No puede estar en blanco" + "<br>";
                        }
                        else
                        {
                            NumeroExpediente = rowDataList[0].ToString();
                            Errores = Errores + "Sin errores <br>";

                            string Controller = "Asignacion";
                            string Method = "AsignacionType";
                            string id = NumeroExpediente +"|"+Modelo.Status+"|"+Modelo.Errores;

                            string result = await employeeProvider.Get(id, Controller, Method);
                            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                            Errores = Errores + jsonResult;


                        }
                    }
                    Modelo.Errores = Errores;
                }
            }
            Modelo.Status = "Se crearon los expedientes, valide los registros que presentan error ";

            return View("index", Modelo);
        }


        public async Task<ActionResult> DataSolicitante(string id)
        {
            string Controller = "CaracterizacionSolicitante";
            string Method = "getCaracterizacionSolicitanteidUser";
            string result = await employeeProvider.Get(id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<CaracterizacionSolicitanteModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaracterizacionSolicitanteModel>>(jsonResult.ToString());
            return new JsonResult()
            {
                Data = processModel,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public async Task<ActionResult> DataJuridica(string id)
        {
            string Controller = "CaracterizacionJuridica";
            string Method = "getCaracterizacionJuridica";
            string result = await employeeProvider.Get(id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return new JsonResult()
            {
                Data = processModel,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public async Task<ActionResult> DataRegistro(string id)
        {
            string Controller = "Registro";
            string Method = "getRegistroidUser";
            string result = await employeeProvider.Get(id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<RegistroModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegistroModel>>(jsonResult.ToString());
            return new JsonResult()
            {
                Data = processModel,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public async Task<ActionResult> DataGeneracion(string id)
        {
            string Controller = "GeneracionDocumentos";
            string Method = "getGeneracionDocumentos";
            string result = await employeeProvider.Get(id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<BaldiosPersonaNaturalModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaldiosPersonaNaturalModel>>(jsonResult.ToString());
            return new JsonResult()
            {
                Data = processModel,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public async Task<ActionResult> DelSol(int IdTable)
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
                return Json("ok");
            }
        }

        public async Task<ActionResult> DelJur(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CaracterizacionJuridica";
            string Method = "getCaracterizacionJuridicadelete";
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

        public async Task<ActionResult> DelReg(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Registro";
            string Method = "getRegistrodelete";
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

        public async Task<ActionResult> DelGen(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "GeneracionDocumentos";
            string Method = "getGeneracionDocumentosdelete";
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


    }
}