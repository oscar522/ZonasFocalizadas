using AspNetIdentity.WebApi.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/assessments")]
    public class AssessmentsController : BaseApiController
    {
        private AssessmentsLogic assessmentsLogic;

        public AssessmentsController()
        {
            assessmentsLogic = new AssessmentsLogic();
        }

        [Authorize(Roles = "Administrator")]
        [Route("getassessments/{id}", Name = "GetAssessments")]
        public async Task<IHttpActionResult> GetAssessments(int Id)
        {
            string result = await Task.Run(() => assessmentsLogic.GetAssessmentsByAccountId(Id));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}