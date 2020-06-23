using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;
using AspNetIdentity.WebApi.Models;
using System;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/CaracterizacionJuridicaResumen")]
    public class CaracterizacionJuridicaResumenController : ApiController
    {
        [Authorize]
        [Route("getConsultar")]
        public List<CaracterizacionJuridicaModel> GetGestion()
        {
            CaracterizacionJuridicaResumenLogic a = new CaracterizacionJuridicaResumenLogic();
            return a.Consultar();
        }
    }
}