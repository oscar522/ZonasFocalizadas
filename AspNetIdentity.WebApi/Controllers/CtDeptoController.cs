using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctdepto")]
    public class CtDeptoController : ApiController
    {
        [Authorize]
        [Route("gethvctdeptoid/{id}")]
        public CtDeptoModel Get(int id)
           
        {
            var model = new CtDeptoModel();
            if (id != 0) {
                CtDeptoLogic a = new CtDeptoLogic();
                model=  a.ConsultarId(id);
            }
           
            return model;
        }

        [Authorize]
        [Route("gethvctdepto/{IdP}")]
        public List<CtDeptoModel> Get(string IdP)
        {
            CtDeptoLogic a = new CtDeptoLogic();
            var model = new List<CtDeptoModel>();
            if (IdP.Equals("0") || IdP.Equals("") || IdP is null)
            {
                model = a.Consulta();
            }
            else {
                model = a.ConsultarIdP(IdP);
            }
            return model;
        }

        [Authorize]
        [Route("gethvctdepto")]
        public List<CtDeptoModel> Get()
        {
            CtDeptoLogic a = new CtDeptoLogic();
            var model = new List<CtDeptoModel>();
                model = a.Consulta();
            return model;
        }

        [HttpPost]
        [Authorize]
        [Route("hvctdeptocreate")]
        public IHttpActionResult Post(CtDeptoModel b)
        {
            CtDeptoLogic a = new CtDeptoLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctdeptoupdate")]
        public IHttpActionResult Put(CtDeptoModel b)
        {
            CtDeptoLogic a = new CtDeptoLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctdeptodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CtDeptoLogic a = new CtDeptoLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}