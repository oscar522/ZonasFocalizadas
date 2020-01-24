using AspNetIdentity.WebClientAdmin.Models;
using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.WebClientAdmin.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    public class UsersController : BaseController
    {
        private UsersProvider _usersProvider;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        UsersProvider usersProvider
        {
            get
            {
                if (_usersProvider == null)
                {
                    _usersProvider = new UsersProvider(bearerToken);
                }

                return _usersProvider;
            }
            set
            {
                _usersProvider = value;
            }
        }
        
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            List<UsersModel> usersModels = await GetUsers();
            return View(usersModels);
        }

        [Authorize]
        public async Task<ActionResult> UserModal(int Id)
        {
            string result = await usersProvider.GetUserById(Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            UsersModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<UsersModel>(jsonResult.ToString());

            return PartialView("UserModal", processModel);
        }

        [Authorize]
        public async Task<ActionResult> Delete(int Id)
        {
            string result = await usersProvider.DeleteUser(Id);

            List<UsersModel> usersModels = await GetUsers();
            return View("Index", usersModels);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> UserModal(UsersModel model)
        {
            if (ModelState.IsValid)
            {
                IDictionary<string,string> keyValuePairs = ObjectToDictionaryHelper.ToDictionary(model);
                string result = await usersProvider.UpdateUser(keyValuePairs);
            }

            List<UsersModel> usersModels = await GetUsers();
            return View("Index", usersModels);
        }

        [Authorize]
        public async Task<ActionResult> Create()
        {
            BTObject bTObject = GetTokenObject();

            RegisterViewModel registerViewModel =
                await Task.Run(
                    () => new RegisterViewModel()
                    {
                        Level = 2,
                        RoleName = "Manager",
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
                var jwtProvider = JwtProvider.Create();
                IdentityResult result = string.IsNullOrEmpty(await jwtProvider.Register(model)) ? IdentityResult.Success : IdentityResult.Failed();
                


                //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                //UserManager.registerViewModel = model;
                //var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    //await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Users");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private async Task<List<UsersModel>> GetUsers()
        {
            int Id = GetTokenObject().AccountId;
            string result = await usersProvider.GetUsers(Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<UsersModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UsersModel>>(jsonResult.ToString());

            return processModel;
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