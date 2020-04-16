using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/CaracterizacionJuridica")]
    public class CaracterizacionJuridicaController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getCaracterizacionJuridicaid/{id}")]
        public CaracterizacionJuridicaModel Get(int id)
        {
            CaracterizacionJuridicaLogic a = new CaracterizacionJuridicaLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getCaracterizacionJuridicaCatalogoid/{id}")]
        public List<CaracterizacionJuridicaCatalogosModel> GetCatalogo(int id)
        {
            CaracterizacionJuridicaLogic a = new CaracterizacionJuridicaLogic();
            return a.ConsultarCatalogo(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getCaracterizacionJuridica/{id}")]
        public List<BaldiosPersonaNaturalModel> GetExp(string id)
        {
            CaracterizacionJuridicaLogic a = new CaracterizacionJuridicaLogic();
            return a.Consulta(id);
        }

        [HttpPost]
        [Authorize]
        [Route("CaracterizacionJuridicacreate")]
        public IHttpActionResult Post(CaracterizacionJuridicaModel b)
        {
            CaracterizacionJuridicaLogic a = new CaracterizacionJuridicaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("CaracterizacionJuridicaupdate")]
        public IHttpActionResult Put(CaracterizacionJuridicaModel b)
        {
            CaracterizacionJuridicaLogic a = new CaracterizacionJuridicaLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getCaracterizacionJuridicadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CaracterizacionJuridicaLogic a = new CaracterizacionJuridicaLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}