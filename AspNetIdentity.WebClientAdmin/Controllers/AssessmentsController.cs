using AspNetIdentity.WebClientAdmin.Models;
using AspNetIdentity.WebClientAdmin.Providers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    public class AssessmentsController : BaseController
    {
        private AssessmentsProvider _assessmentsProvider;

        AssessmentsProvider assessmentsProvider
        {
            get
            {
                if (_assessmentsProvider == null)
                {
                    _assessmentsProvider = new AssessmentsProvider(bearerToken);
                }

                return _assessmentsProvider;
            }
            set
            {
                _assessmentsProvider = value;
            }
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            List<UsersModel> usersModels = await GetAssessments();
            return View(usersModels);
        }

        private async Task<List<UsersModel>> GetAssessments()
        {
            int Id = GetTokenObject().AccountId;
            string result = await assessmentsProvider.GetAssessments(Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<UsersModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UsersModel>>(jsonResult.ToString());

            return processModel;
        }

        [Authorize]
        public async Task<ActionResult> Create()
        {
            BTObject bTObject = GetTokenObject();

            RegisterViewModel registerViewModel =
                await Task.Run(
                    () => new RegisterViewModel()
                    {
                        Level = 3,
                        RoleName = "User",
                        Id_User = bTObject.nameid,
                        Id_Account = bTObject.AccountId,
                        RootUser = false
                    });

            return View(registerViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Username = model.Email;

                var content = new[]
                    {
                        new KeyValuePair<string, string>("Name", model.Name),
                        new KeyValuePair<string, string>("Level", model.Level.ToString()),
                        new KeyValuePair<string, string>("Username", model.Username),
                        new KeyValuePair<string, string>("Email", model.Email),
                        new KeyValuePair<string, string>("FirstName", model.FirstName),
                        new KeyValuePair<string, string>("LastName", model.LastName),
                        new KeyValuePair<string, string>("Password", model.Password),
                        new KeyValuePair<string, string>("RoleName", model.RoleName),
                        new KeyValuePair<string, string>("ConfirmPassword", model.ConfirmPassword),
                        new KeyValuePair<string, string>("Id_User", model.Id_User),
                        new KeyValuePair<string, string>("Id_Account", model.Id_Account.ToString()),
                        new KeyValuePair<string, string>("RootUser", model.RootUser.ToString())
                    };



                IdentityResult result = string.IsNullOrEmpty(await assessmentsProvider.PostAssessments(content)) ? IdentityResult.Success : IdentityResult.Failed();

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Assessments");
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion
    }
}