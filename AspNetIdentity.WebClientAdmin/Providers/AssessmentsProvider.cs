using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetIdentity.WebClientAdmin.Providers
{
    public class AssessmentsProvider : BaseProvider
    {
        private static readonly string _tokenUri = string.Format("{0}api/assessments/", ConfigurationManager.AppSettings["HTTPRM_PROXY"]);

        private string _httpCookieToken;

        public AssessmentsProvider(string httpCookieToken)
        {
            _httpCookieToken = httpCookieToken;
        }

        public async Task<string> GetAssessments(int Id)
        {
            string uriString = string.Format("{0}getassessments/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }

        public async Task<string> PostAssessments(IEnumerable<KeyValuePair<string, string>> contentForm)
        {
            string uriString = string.Format("{0}api/accounts/create", ConfigurationManager.AppSettings["HTTPRM_PROXY"]);
            var response = await Post(uriString, _httpCookieToken, contentForm);

            return response;
        }

    }
}