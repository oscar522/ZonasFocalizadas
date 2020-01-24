using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace AspNetIdentity.WebClientAdmin.Providers
{
    public class UsersProvider : BaseProvider
    {
        private static readonly string _tokenUri = string.Format("{0}api/users/", ConfigurationManager.AppSettings["HTTPRM_PROXY"]);

        private string _httpCookieToken;

        public UsersProvider(string httpCookieToken)
        {
            _httpCookieToken = httpCookieToken;
        }

        public async Task<string> GetUsers(int Id)
        {
            string uriString = string.Format("{0}getusers/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }

        public async Task<string> GetUserById(int Id)
        {
            string uriString = string.Format("{0}getuser/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }

        public async Task<string> UpdateUser(IDictionary<string, string> ContentForm)
        {
            string uriString = string.Format("{0}updateuser", _tokenUri);
            var response = await Put(uriString, _httpCookieToken, ContentForm);

            return response;
        }

        public async Task<string> DeleteUser(int Id)
        {
            string uriString = string.Format("{0}deleteuser/{1}", _tokenUri, Id);
            var response = await Delete(uriString, _httpCookieToken);

            return response;
        }
    }
}