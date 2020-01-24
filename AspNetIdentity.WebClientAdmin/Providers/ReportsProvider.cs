using System.Configuration;
using System.Threading.Tasks;

namespace AspNetIdentity.WebClientAdmin.Providers
{
    public class ReportsProvider : BaseProvider
    {
        private static readonly string _tokenUri = string.Format("{0}api/reports/", ConfigurationManager.AppSettings["HTTPRM_PROXY"]);
        
        private string _httpCookieToken;

        public ReportsProvider(string httpCookieToken)
        {
            _httpCookieToken = httpCookieToken;
        }

        public async Task<string> GetReports(string Id)
        {
            string uriString = string.Format("{0}getreports/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }

        public async Task<string> GetReportFile(int Id)
        {
            string uriString = string.Format("{0}getreportfile/{1}", _tokenUri, Id);
            var response = await Get(uriString, _httpCookieToken);

            return response;
        }
    }
}