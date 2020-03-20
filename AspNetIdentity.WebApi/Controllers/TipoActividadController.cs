using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/TipoActividad")]
    public class TipoActividadController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getTipoActividadid/{id}")]
        public TipoActividadModel Get(int id)
        {
            TipoActividadLogic a = new TipoActividadLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getTipoActividad")]
        public List<TipoActividadModel> Get()
        {
            TipoActividadLogic a = new TipoActividadLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("TipoActividadcreate")]
        public IHttpActionResult Post(TipoActividadModel b)
        {
            TipoActividadLogic a = new TipoActividadLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("TipoActividadupdate")]
        public IHttpActionResult Put(TipoActividadModel b)
        {
            TipoActividadLogic a = new TipoActividadLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getTipoActividaddelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            TipoActividadLogic a = new TipoActividadLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}