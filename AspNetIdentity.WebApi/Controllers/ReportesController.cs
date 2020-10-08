using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Text.RegularExpressions;
using System.IO;
using CsvHelper;
using System.Globalization;
using System;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Reportes")] //nombre del conrolador
    public class ReportesController : ApiController
    {
        //[Authorize]
        [Route("getRegistro")] //metodo del controlador
        public string  GetResgistro()
        {
            ReporteLogic a = new ReporteLogic();

            var key = System.Guid.NewGuid().ToString();
            using (var writer = new StreamWriter("C:\\ReportAnt\\ReporteRegistro"+ key +".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                ReporteLogic Report_ = new ReporteLogic();
                csv.WriteRecords(Report_.ConsultaRegistro());
            }
            Byte[] bytes = File.ReadAllBytes("C:\\ReportAnt\\ReporteRegistro" + key + ".csv");
            String file = Convert.ToBase64String(bytes);
            
            return file;
        }

        //[Authorize]
        [Route("getJuridica")] //metodo del controlador
        public string GetJuridica()
        {
            ReporteLogic a = new ReporteLogic();

            var key = System.Guid.NewGuid().ToString();
            using (var writer = new StreamWriter("C:\\ReportAnt\\ReporteJuridica" + key + ".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                ReporteLogic Report_ = new ReporteLogic();
                csv.WriteRecords(Report_.ConsultaJuridica());
            }
            Byte[] bytes = File.ReadAllBytes("C:\\ReportAnt\\ReporteJuridica" + key + ".csv");
            String file = Convert.ToBase64String(bytes);

            return file;
        }

        //[Authorize]
        [Route("getSolicitante")] //metodo del controlador
        public string GetSolicitante()
        {
            ReporteLogic a = new ReporteLogic();

            var key = System.Guid.NewGuid().ToString();
            using (var writer = new StreamWriter("C:\\ReportAnt\\ReporteSolicitante" + key + ".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                ReporteLogic Report_ = new ReporteLogic();
                csv.WriteRecords(Report_.ConsultaSolicitante());
            }
            Byte[] bytes = File.ReadAllBytes("C:\\ReportAnt\\ReporteSolicitante" + key + ".csv");
            String file = Convert.ToBase64String(bytes);

            return file;
        }
    }
}