using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/RetencionDocumental")]
    public class RetencionDocumentalController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getRetencionDocumental/{id}")]
        public RetencionDocumentalModel Get(int id)
        {
            RetencionDocumentalLogic a = new RetencionDocumentalLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getRetencionDocumentalGrupo/{id}")]
        public List<RetencionDocumentalModel> GetGrupo(int id)
        {
            RetencionDocumentalLogic a = new RetencionDocumentalLogic();
            return a.ConsultarGrupoId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getRetencionDocumental")]
        public List<RetencionDocumentalModel> Get()
        {
            RetencionDocumentalLogic a = new RetencionDocumentalLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("RetencionDocumentalcreate")]
        public IHttpActionResult Post(RetencionDocumentalModel b)
        {
            RetencionDocumentalLogic a = new RetencionDocumentalLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Nombre)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("RetencionDocumentalupdate")]
        public IHttpActionResult Put(RetencionDocumentalModel b)
        {
            RetencionDocumentalLogic a = new RetencionDocumentalLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Nombre)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getRetencionDocumentaldelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            RetencionDocumentalLogic a = new RetencionDocumentalLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}