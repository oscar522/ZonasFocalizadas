using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/CaracterizacionAgronomica")]
    public class CaracterizacionAgronomicaController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getCaracterizacionAgronomicaid/{id}")]
        public CaracterizacionAgronomicaModel Get(int id)
        {
            CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
            return a.ConsultarId(id);
        }

        //[Authorize]
        //[Route("getCaracterizacionAgronomicaidExp/{id}")]
        //public CaracterizacionAgronomicaModel GetExp(int id)
        //{
        //    CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
        //    return a.ConsultarIdExp(id);
        //}

        [Authorize]
        [Route("getCaracterizacionAgronomicaCatalogoid/{id}")]
        public List<CaracterizacionAgronomicaCatalogosModel> GetCatalogo(string id)
        {
            CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
            return a.ConsultarCatalogo(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getCaracterizacionAgronomica/{id}")]
        public List<BaldiosPersonaNaturalModel> GetExp(string id)
        {
            CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
            return a.Consulta(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getCaracterizacionAgronomica")]
        public List<CaracterizacionSolicitanteModel> GetAll()
        {
            CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("CaracterizacionAgronomicacreate")]
        public IHttpActionResult Post(CaracterizacionAgronomicaModel b)
        {
            CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("CaracterizacionAgronomicaupdate")]
        public IHttpActionResult Put(CaracterizacionAgronomicaModel b)
        {
            CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getCaracterizacionAgronomicadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CaracterizacionAgronomicaLogic a = new CaracterizacionAgronomicaLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}