using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/CaracterizacionSolicitante")]
    public class CaracterizacionSolicitanteController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getCaracterizacionSolicitanteid/{id}")]
        public CaracterizacionSolicitanteModel Get(int id)
        {
            CaracterizacionSolicitanteLogic a = new CaracterizacionSolicitanteLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getCaracterizacionSolicitanteidUser/{id}")]
        public List<CaracterizacionSolicitanteModel> GetUser(string id)
        {
            CaracterizacionSolicitanteLogic a = new CaracterizacionSolicitanteLogic();
            return a.ConsultarIdUser(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getCaracterizacionSolicitante")]
        public List<CaracterizacionSolicitanteModel> Get()
        {
            CaracterizacionSolicitanteLogic a = new CaracterizacionSolicitanteLogic();
            return a.Consulta();
        }

        //[HttpPost]
        //[Authorize]
        //[Route("CaracterizacionSolicitantecreate")]
        //public IHttpActionResult Post(CaracterizacionSolicitanteModel b)
        //{
        //    CaracterizacionSolicitanteLogic a = new CaracterizacionSolicitanteLogic();
        //    var result = a.Crear(b);
        //    if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
        //    return NotFound();
        //}

        [HttpPut]
        [Authorize]
        [Route("CaracterizacionSolicitanteupdate")]
        public IHttpActionResult Put(CaracterizacionSolicitanteModel b)
        {
            CaracterizacionSolicitanteLogic a = new CaracterizacionSolicitanteLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getCaracterizacionSolicitantedelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CaracterizacionSolicitanteLogic a = new CaracterizacionSolicitanteLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}