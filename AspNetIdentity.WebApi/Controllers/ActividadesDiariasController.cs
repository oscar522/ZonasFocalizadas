using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/ActividadesDiarias")]
    public class ActividadesDiariasController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getActividadesDiariasid/{id}")]
        public List<ActividadesDiariasModel> Get(string id)
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getActividadesDiarias")]
        public List<ActividadesDiariasModel> Get()
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            return a.Consulta();
        }

        [Authorize]
        [Route("getRol")]
        public List<CtDeptoModel> GetRol()
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            return a.ConsultaRol();
        }

        [Authorize]
        [Route("getProceso")]
        public List<CtPaisModel> GetProceso()
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            return a.ConsultaProceso();
        }

        [Authorize]
        [Route("getModalidad")]
        public List<CtPaisModel> GetModalidad()
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            return a.ConsultaModalidad();
        }

        [HttpPost]
        [Authorize]
        [Route("ActividadesDiariascreate")]
        public IHttpActionResult Post(ActividadesDiariasModel b)
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("ActividadesDiariasupdate")]
        public IHttpActionResult Put(ActividadesDiariasModel b)
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getActividadesDiariasdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            ActividadesDiariasLogic a = new ActividadesDiariasLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}