using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.WebClientAdmin.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    public class EmployeeController : BaseController
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

        [Authorize]
        public async Task<ActionResult> PrivacyPolicy()
        {
            string Id = GetTokenObject().nameid;
            string result = await employeeProvider.GetPrivacyPolicy(Id);
            string jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result).ToString();
            PrivacyPolicyModel privacyPolicyModel = JObject.Parse(jsonResult).ToObject<PrivacyPolicyModel>();

            return View(privacyPolicyModel);
        }

        [Authorize]
        public async Task<ActionResult> AboutTheCompany()
        {
            string Id = GetTokenObject().nameid;
            string result = await employeeProvider.GetAbout(Id);
            string jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result).ToString();
            AboutModel aboutModel = JObject.Parse(jsonResult).ToObject<AboutModel>();

            return View(aboutModel);
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> MyProcess()
        {
            string Id = GetTokenObject().nameid;
            string result = await employeeProvider.GetProcess(Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<ProcessModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProcessModel>>(jsonResult.ToString());

            return View(processModel);
        }

        [Authorize]
        public async Task<ActionResult> TechnicalTest(int Id, FormCollection form)
        {
            //string Id = form["Id_UserTest"].ToString();
            string Answers = form["Answers"];

            if (!string.IsNullOrEmpty(Answers))
            {
                QA[] qAs = Newtonsoft.Json.JsonConvert.DeserializeObject<QA[]>(Answers);

                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                for (int i = 0; i < qAs.Length; i++)
                {
                    keyValuePairs.Add(qAs[i].q, qAs[i].a);
                }

                Answers = Newtonsoft.Json.JsonConvert.SerializeObject(keyValuePairs);
            }

            string result = await employeeProvider.GetTechnicalTest(Id.ToString(), Answers);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<TechnicalTestQuestion> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TechnicalTestQuestion>>(jsonResult.ToString());

            if (processModel.Count == 0)
            {
                return RedirectToAction("MyProcess", "Employee");
            }

            return View(processModel);
        }

        //[Authorize]
        //public async Task<ActionResult> TechnicalTest(int Id, string Answers)
        //{
        //    if(!string.IsNullOrEmpty(Answers))
        //    {
        //        QA[] qAs = Newtonsoft.Json.JsonConvert.DeserializeObject<QA[]>(Answers);

        //        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        //        for(int i = 0; i < qAs.Length; i++)
        //        {
        //            keyValuePairs.Add(qAs[i].q, qAs[i].a);
        //        }

        //        Answers = Newtonsoft.Json.JsonConvert.SerializeObject(keyValuePairs);
        //    }

        //    string result = await employeeProvider.GetTechnicalTest(Id.ToString(), Answers);
        //    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //    List<TechnicalTestQuestion> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TechnicalTestQuestion>>(jsonResult.ToString());

        //    return View(processModel);
        //}

        [Authorize]
        public ActionResult TechnicalTestNext(string Id, string Answers)
        {
            //string result = await employeeProvider.GetTechnicalTest(Id);
            //var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            //List<TechnicalTestQuestion> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TechnicalTestQuestion>>(jsonResult.ToString());

            return View();
        }
    }
}