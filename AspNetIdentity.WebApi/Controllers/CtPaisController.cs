using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Text.RegularExpressions;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctpais")]
    public class CtPaisController : ApiController
    {
        //[Authorize]
        [Route("gethvctpaisid/{id}")]
        public CtPaisModel Get(int id)
        {
            CtPaisLogic a = new CtPaisLogic();
            return a.ConsultarId(id);
        }

        //[Authorize]
        [Route("gethvctpais")]
        public List<CtPaisModel> Get()
        {
            CtPaisLogic a = new CtPaisLogic();
            return a.Consulta();
        }

        [HttpPost]
        //[Authorize]
        [Route("hvctpaiscreate")]
        public IHttpActionResult Post(CtPaisModel b)
        {      
            CtPaisLogic a = new CtPaisLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        //[Authorize]
        [Route("hvctpaisupdate")]
        public IHttpActionResult Put(CtPaisModel b)
        {
            CtPaisLogic a = new CtPaisLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        //[Authorize]
        [Route("gethvctpaisdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CtPaisLogic a = new CtPaisLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}