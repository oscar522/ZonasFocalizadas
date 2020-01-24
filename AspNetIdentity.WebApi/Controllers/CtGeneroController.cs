using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctgenero")]
    public class CtGeneroController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("gethvctgeneroid/{id}")]
        public CtGeneroModel Get(int id)
        {
            CtGeneroLogic a = new CtGeneroLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("gethvctgenero")]
        public List<CtGeneroModel> Get()
        {
            CtGeneroLogic a = new CtGeneroLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctgenerocreate")]
        public IHttpActionResult Post(CtGeneroModel b)
        {
            CtGeneroLogic a = new CtGeneroLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctgeneroupdate")]
        public IHttpActionResult Put(CtGeneroModel b)
        {
            CtGeneroLogic a = new CtGeneroLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctgenerodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CtGeneroLogic a = new CtGeneroLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}