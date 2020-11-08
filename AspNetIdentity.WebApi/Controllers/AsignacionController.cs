using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Asignacion")]
    public class AsignacionController : ApiController
    {
        [Authorize]
        [Route("AsignacionType/{id}")]
        public string Get(string id)
        {
            string[] Request = id.Split('|');

            AsignacionLogic a = new AsignacionLogic();
            return a.AsignarExp(Request[0], Request[1], Request[2]);
        }
    }
}