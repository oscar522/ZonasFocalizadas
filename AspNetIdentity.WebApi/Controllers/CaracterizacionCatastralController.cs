using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/CaracterizacionCatastral")]
    public class CaracterizacionCatastralController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getCaracterizacionCatastralid/{id}")]
        public CaracterizacionCatastralModel Get(int id)
        {
            CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
            return a.ConsultarId(id);
        }

        //[Authorize]
        //[Route("getCaracterizacionCatastralidExp/{id}")]
        //public CaracterizacionCatastralModel GetExp(int id)
        //{
        //    CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
        //    return a.ConsultarIdExp(id);
        //}

        [Authorize]
        [Route("getCaracterizacionCatastralCatalogoid/{id}")]
        public List<CaracterizacionCatastralCatalogosModel> GetCatalogo(string id)
        {
            CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
            return a.ConsultarCatalogo(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getCaracterizacionCatastral/{id}")]
        public List<BaldiosPersonaNaturalModel> GetExp(string id)
        {
            CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
            return a.Consulta(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getCaracterizacionCatastral")]
        public List<CaracterizacionSolicitanteModel> GetAll()
        {
            CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("CaracterizacionCatastralcreate")]
        public IHttpActionResult Post(CaracterizacionCatastralModel b)
        {
            CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("CaracterizacionCatastralupdate")]
        public IHttpActionResult Put(CaracterizacionCatastralModel b)
        {
            CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getCaracterizacionCatastraldelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CaracterizacionCatastalLogic a = new CaracterizacionCatastalLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}