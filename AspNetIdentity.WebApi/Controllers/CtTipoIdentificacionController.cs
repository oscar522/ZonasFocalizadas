using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvcttipoidentificacion")]
    public class CtTipoIdentificacionController : ApiController
    {
        [Authorize]
        [Route("gethvcttipoidentificacionid/{id}")]
        public CtTipoIdentificacionModel Get(int id)
        {
            CtTipoIdentificacionLogic a = new CtTipoIdentificacionLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvcttipoidentificacion")]
        public List<CtTipoIdentificacionModel> Get()
        {
            CtTipoIdentificacionLogic a = new CtTipoIdentificacionLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvcttipoidentificacioncreate")]
        public IHttpActionResult Post(CtTipoIdentificacionModel b)
        {
            CtTipoIdentificacionLogic a = new CtTipoIdentificacionLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvcttipoidentificacionupdate")]
        public IHttpActionResult Put(CtTipoIdentificacionModel b)
        {
            CtTipoIdentificacionLogic a = new CtTipoIdentificacionLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvcttipoidentificaciondelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CtTipoIdentificacionLogic a = new CtTipoIdentificacionLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}