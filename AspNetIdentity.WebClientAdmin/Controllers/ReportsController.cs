using AspNetIdentity.WebClientAdmin.Models;
using AspNetIdentity.WebClientAdmin.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    public class ReportsController : BaseController
    {
        private ReportsProvider _reportsProvider;

        ReportsProvider reportsProvider
        {
            get
            {
                if (_reportsProvider == null)
                {
                    _reportsProvider = new ReportsProvider(bearerToken);
                }

                return _reportsProvider;
            }
            set
            {
                _reportsProvider = value;
            }
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            string Id = GetTokenObject().nameid;
            string result = await reportsProvider.GetReports(Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ReportsModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReportsModel>>(jsonResult.ToString());

            return View(processModel);
        }

        [Authorize]
        public async Task<FileContentResult> GetReport(int id)
        {
            string result = await reportsProvider.GetReportFile(id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(result);
            

            byte[] fileContents = Convert.FromBase64String(jsonResult);                                     // The binary content to send to the response.
            string contentType = "application/pdf";                                                         // The content type (MIME type).
            string fileDownloadName = string.Format("TST{0}.pdf", DateTime.Now.ToString("yyyyMMddhhmm"));   // The file name to use in the file-download dialog box that is displayed in the browser.

            return File(fileContents, contentType, fileDownloadName);
        }
    }
}