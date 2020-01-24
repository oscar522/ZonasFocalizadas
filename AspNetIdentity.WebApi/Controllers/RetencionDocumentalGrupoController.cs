using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/RetencionDocumentalGrupo")]
    public class RetencionDocumentalGrupoGrupoController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getRetencionDocumentalGrupo/{id}")]
        public RetencionDocumentalGrupoModel Get(int id)
        {
            RetencionDocumentalGrupoLogic a = new RetencionDocumentalGrupoLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getRetencionDocumentalGrupo")]
        public List<RetencionDocumentalGrupoModel> Get()
        {
            RetencionDocumentalGrupoLogic a = new RetencionDocumentalGrupoLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("RetencionDocumentalGrupocreate")]
        public IHttpActionResult Post(RetencionDocumentalGrupoModel b)
        {
            RetencionDocumentalGrupoLogic a = new RetencionDocumentalGrupoLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NombreGrupo)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("RetencionDocumentalGrupoupdate")]
        public IHttpActionResult Put(RetencionDocumentalGrupoModel b)
        {
            RetencionDocumentalGrupoLogic a = new RetencionDocumentalGrupoLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NombreGrupo)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getRetencionDocumentalGrupodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            RetencionDocumentalGrupoLogic a = new RetencionDocumentalGrupoLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}