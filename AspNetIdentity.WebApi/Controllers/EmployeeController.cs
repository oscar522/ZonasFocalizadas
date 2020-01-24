using AspNetIdentity.WebApi.Logic;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : BaseApiController
    {
        private EmployeeLogic employeeLogic;

        public EmployeeController()
        {
            employeeLogic = new EmployeeLogic();
        }

        [Authorize(Roles = "User")]
        [Route("privacypolicy/{id:guid}", Name = "PrivacyPolicy")]
        public async Task<IHttpActionResult> GetPrivacyPolicy(string Id)
        {
            string result = await Task.Run(()=> employeeLogic.GetPrivPoliByUserId(Id.ToString()));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Authorize(Roles = "User")]
        [Route("about/{id:guid}", Name = "About")]
        public async Task<IHttpActionResult> GetAbout(string Id)
        {
            string result = await Task.Run(() => employeeLogic.GetAboutByUserId(Id));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Authorize(Roles = "User")]
        [Route("process/{id:guid}", Name = "Process")]
        public async Task<IHttpActionResult> GetProcess(string Id)
        {
            string result = await Task.Run(() => employeeLogic.GetMyProcessByUserId(Id));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [Route("technicaltest")]
        public async Task<IHttpActionResult> PostTechnicalTest(TechicalTestBindingModel techicalTestBindingModel)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(techicalTestBindingModel.Answers))
            {
                Dictionary<string, string> keyValuePairs = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(techicalTestBindingModel.Answers);
                result = await Task.Run(() => employeeLogic.SetTechnicalTest(techicalTestBindingModel.Id_UserTest, keyValuePairs));
            }
            else
            {
                result = await Task.Run(() => employeeLogic.GetTechnicalTestByTestId(techicalTestBindingModel.Id_UserTest));
            }

            if (!string.IsNullOrEmpty(result)) return Ok(result);

            return NotFound();
        }
    }
}