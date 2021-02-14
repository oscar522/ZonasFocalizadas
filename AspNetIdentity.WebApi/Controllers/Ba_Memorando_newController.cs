using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Ba_Memorando_new")]
    public class Ba_Memorando_new_newController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getBa_Memorando_newid/{id}")]
        public Ba_Memorando_newModel Get(int id)
        {
            Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
            return a.ConsultarId(id);
        }

        //[Authorize]
        //[Route("getBa_Memorando_newidExp/{id}")]
        //public Ba_Memorando_newModel GetExp(int id)
        //{
        //    Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
        //    return a.ConsultarIdExp(id);
        //}

        [Authorize]
        [Route("getBa_Memorando_newCatalogoid/{id}")]
        public List<Ba_MemorandoCatalogosModel> GetCatalogo(string id)
        {
            Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
            return a.ConsultarCatalogo(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getBa_Memorando_new/{id}")]
        public List<Ba_Memorando_newModel> GetExp(string id)
        {
            Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
            return a.Consulta(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getBa_Memorando_new")]
        public List<Ba_Memorando_newModel> GetAll()
        {
            Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("Ba_Memorando_newcreate")]
        public IHttpActionResult Post(Ba_Memorando_newModel b)
        {
            Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("Ba_Memorando_newupdate")]
        public IHttpActionResult Put(Ba_Memorando_newModel b)
        {
            Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getBa_Memorando_newdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            Ba_Memorando_newLogic a = new Ba_Memorando_newLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}