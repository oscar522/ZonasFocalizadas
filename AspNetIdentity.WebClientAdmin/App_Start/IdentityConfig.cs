using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using AspNetIdentity.WebClientAdmin.Models;
using System.Web;

namespace AspNetIdentity.WebClientAdmin
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public RegisterViewModel registerViewModel { get; set; }

        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public override async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            var jwtProvider = Providers.JwtProvider.Create();
            string register = await jwtProvider.Register(registerViewModel);

            if (register == null)
            {
                return IdentityResult.Failed();
            }
            else
            {
                return IdentityResult.Success;
            }
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public override async Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var jwtProvider = Providers.JwtProvider.Create();
            string token = await jwtProvider.GetTokenAsync(userName, password);

            if (token == null)
            {
                return SignInStatus.Failure;
            }
            else
            {
                Dictionary<string, string> keyValuePairsToken = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

                HttpCookie httpCookie = HttpContext.Current.Response.Cookies.Get("5XCUmffguLUnf5UD");
                if (httpCookie != null) HttpContext.Current.Response.Cookies.Remove("5XCUmffguLUnf5UD");

                httpCookie = new HttpCookie("5XCUmffguLUnf5UD")
                {
                    Expires = DateTime.Now.AddSeconds(Convert.ToDouble(keyValuePairsToken["expires_in"])),
                    Value = keyValuePairsToken["access_token"]
                };
                HttpContext.Current.Response.Cookies.Add(httpCookie);

                // decode payload
                dynamic payload = jwtProvider.DecodePayload(token);

                // create an identity claim
                ClaimsIdentity claims = jwtProvider.CreateIdentity(true, userName, payload);

                // sign in
                var context = HttpContext.Current.Request.GetOwinContext();
                var authenticationManager = context.Authentication;
                authenticationManager.SignIn(claims);

                return SignInStatus.Success;
            }
        }

        private async Task<SignInStatus> SignInOrTwoFactor(ApplicationUser user, bool isPersistent)
        {
            SignInStatus signInStatu;
            string str = Convert.ToString(user.Id);
            Task<bool> cultureAwaiter = this.UserManager.GetTwoFactorEnabledAsync(user.Id);
            if (await cultureAwaiter)
            {
                Task<IList<string>> providerAwaiter = this.UserManager.GetValidTwoFactorProvidersAsync(user.Id);
                IList<string> listProviders = await providerAwaiter;
                if (listProviders.Count > 0)
                {
                    Task<bool> cultureAwaiter2 = AuthenticationManagerExtensions.TwoFactorBrowserRememberedAsync(this.AuthenticationManager, str);
                    if (!await cultureAwaiter2)
                    {
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity("TwoFactorCookie");
                        claimsIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", str));
                        this.AuthenticationManager.SignIn(new ClaimsIdentity[] { claimsIdentity });
                        signInStatu = SignInStatus.RequiresVerification;
                        return signInStatu;
                    }
                }
            }
            Task cultureAwaiter3 = this.SignInAsync(user, isPersistent, false);
            await cultureAwaiter3;
            signInStatu = SignInStatus.Success;
            return signInStatu;
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
