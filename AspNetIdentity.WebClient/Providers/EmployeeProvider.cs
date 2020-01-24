using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetIdentity.WebClient.Providers
{
    public class EmployeeProvider
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
            var response = await Get(uriString);

            return response;
        }

        public async Task<string> GetAbout(string Id)
        {
            string uriString = string.Format("{0}about/{1}", _tokenUri, Id);
            var response = await Get(uriString);

            return response;
        }

        public async Task<string> GetProcess(string Id)
        {
            string uriString = string.Format("{0}process/{1}", _tokenUri, Id);
            var response = await Get(uriString);

            return response;
        }

        public async Task<string> GetTechnicalTest(string Id, string Answers)
        {
            string uriString = string.Format("{0}technicaltest", _tokenUri);

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("Id_UserTest", Id);

            if (!string.IsNullOrEmpty(Answers)) keyValuePairs.Add("Answers", Answers);
            
            var response = await Post(uriString, keyValuePairs);

            return response;
        }

        public async Task<string> Get(string uriString)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(uriString);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", _httpCookieToken);
                
                var response = await client.GetAsync(string.Empty);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> Post(string uriString, IEnumerable<KeyValuePair<string, string>> contentForm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriString);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", _httpCookieToken);

                var content = new FormUrlEncodedContent(contentForm);
                var response = await client.PostAsync(string.Empty, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}