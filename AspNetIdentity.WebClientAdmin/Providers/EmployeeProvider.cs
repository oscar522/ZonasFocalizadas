using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AspNetIdentity.Models;

namespace AspNetIdentity.WebClientAdmin.Providers
{
    public class EmployeeProvider : BaseProvider
    {
        private static readonly string _tokenUri = string.Format("{0}api/employee/", ConfigurationManager.AppSettings["HTTPRM_PROXY"]);
        private string _httpCookieToken;

        public EmployeeProvider(string httpCookieToken)
        {
            _httpCookieToken = httpCookieToken;
        }

        public async Task<string> GetPrivacyPolicy(string Id)
        {
            string uriString = string.Format("{0}privacypolicy/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }

        public async Task<string> GetAbout(string Id)
        {
            string uriString = string.Format("{0}about/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }

        public async Task<string> GetProcess(string Id)
        {
            string uriString = string.Format("{0}process/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }

        public async Task<string> GetTechnicalTest(string Id, string Answers)
        {
            string uriString = string.Format("{0}technicaltest", _tokenUri);

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("Id_UserTest", Id);

            if (!string.IsNullOrEmpty(Answers)) keyValuePairs.Add("Answers", Answers);

            var response = await Post(uriString, _httpCookieToken, keyValuePairs);

            return response;
        }

        public async Task<string> Get(string Id, string Controller, string Method)
        {
            string uriString = "";
            string _tokenUri = string.Format("{0}api/{1}/", ConfigurationManager.AppSettings["HTTPRM_PROXY"], Controller);
            if (Id.Equals("0")) {
                uriString = string.Format("{0}{1}", _tokenUri, Method);
            } else {
                uriString = string.Format("{0}{1}/{2}", _tokenUri, Method,Id);
            }
            var response = await Get(uriString, _httpCookieToken);
            return response;
        }

        public async Task<string> Post(IEnumerable<KeyValuePair<string, string>> contentForm, string Controller, string Method)
        {
            string _tokenUri = string.Format("{0}api/{1}/", ConfigurationManager.AppSettings["HTTPRM_PROXY"], Controller);
            string uriString = string.Format("{0}{1}", _tokenUri, Method);
            var response = await Post(uriString, _httpCookieToken, contentForm);
            return response;
        }

        public async Task<string> Put(IEnumerable<KeyValuePair<string, string>> contentForm, string Controller, string Method)
        {
            string _tokenUri = string.Format("{0}api/{1}/", ConfigurationManager.AppSettings["HTTPRM_PROXY"], Controller);
            string uriString = string.Format("{0}{1}", _tokenUri, Method);
            var response = await Put(uriString, _httpCookieToken, contentForm);
            return response;
        }

        public async Task<string> Delete(string Controller, string Method, string Id)
        {
            string _tokenUri = string.Format("{0}api/{1}/{2}/", ConfigurationManager.AppSettings["HTTPRM_PROXY"], Controller, Method);
            string uriString = string.Format("{0}{1}", _tokenUri, Id);
            var response = await Delete(uriString, _httpCookieToken);
            return response;
        }

    }
}