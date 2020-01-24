using AspNetIdentity.WebClientAdmin.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.WebClientAdmin.Providers
{
    public class JwtProvider
    {
        private static readonly string _tokenUri = ConfigurationManager.AppSettings["HTTPRM_PROXY"];
        private static readonly string _clientId = ConfigurationManager.AppSettings["as:ClientId"];
        private static readonly string _deviceId = Environment.MachineName;
        // default constructor
        public JwtProvider() { }

        public static JwtProvider Create()
        {
            return new JwtProvider();
        }

        public async Task<string> Register(RegisterViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_tokenUri + "api/accounts/create");
                client.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new FormUrlEncodedContent(new[]
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
                    });

                var response = await client.PostAsync(string.Empty, content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> GetTokenAsync(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_tokenUri + "oauth/token");
                client.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("device_id", _deviceId),
                        new KeyValuePair<string, string>("client_id", _clientId)
                    });

                var response = await client.PostAsync(string.Empty, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // return null if unauthenticated
                    return null;
                }
            }
        }

        public JObject DecodePayload(string token)
        {
            var parts = token.Split('.');
            var payload = parts[1];

            var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
            return JObject.Parse(payloadJson);
        }

        public ClaimsIdentity CreateIdentity(bool isAuthenticated, string userName, dynamic payload)
        {
            // decode the payload from token
            // in order to create a claim
            string userId = payload.nameid;
            string[] roles = payload.role.Type == JTokenType.String ? new string[] { payload.role.Value } : payload.role.ToObject(typeof(string[]));

            var jwtIdentity = new ClaimsIdentity(new JwtIdentity(isAuthenticated, userName, DefaultAuthenticationTypes.ApplicationCookie));

            //add user id
            jwtIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));
            //add roles
            foreach (var role in roles)
            {
                jwtIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return jwtIdentity;
        }

        private byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default: throw new System.Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }
    }

    public class JwtIdentity : IIdentity
    {
        private bool _isAuthenticated;
        private string _name;
        private string _authenticationType;

        public JwtIdentity() { }
        public JwtIdentity(bool isAuthenticated, string name, string authenticationType)
        {
            _isAuthenticated = isAuthenticated;
            _name = name;
            _authenticationType = authenticationType;
        }
        public string AuthenticationType
        {
            get
            {
                return _authenticationType;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}