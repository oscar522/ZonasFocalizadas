using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : BaseApiController
    {
        private ReportsLogic reportsLogic;

        public ReportsController()
        {
            reportsLogic = new ReportsLogic();
        }

        [Authorize(Roles = "Manager")]
        [Route("getreports/{id:guid}", Name = "GetReports")]
        public async Task<IHttpActionResult> GetReports(string Id)
        {
            string result = await Task.Run(() => reportsLogic.GetReportsByUserId(Id));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Authorize(Roles = "Manager")]
        [Route("getreportfile/{id}", Name = "GetReportFile")]
        public async Task<IHttpActionResult> GetReportFile(int Id)
        {
            string result = await Task.Run(() => reportsLogic.GetReportById(Id));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}