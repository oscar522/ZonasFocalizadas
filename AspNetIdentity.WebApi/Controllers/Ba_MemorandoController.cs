using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Ba_Memorando")]
    public class Ba_MemorandoController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getBa_Memorandoid/{id}")]
        public Ba_MemorandoModel Get(int id)
        {
            Ba_MemorandoLogic a = new Ba_MemorandoLogic();
            return a.ConsultarId(id);
        }

        //[Authorize]
        //[Route("getBa_MemorandoidExp/{id}")]
        //public Ba_MemorandoModel GetExp(int id)
        //{
        //    Ba_MemorandoLogic a = new Ba_MemorandoLogic();
        //    return a.ConsultarIdExp(id);
        //}

        [Authorize]
        [Route("getBa_MemorandoCatalogoid/{id}")]
        public List<Ba_MemorandoCatalogosModel> GetCatalogo(string id)
        {
            Ba_MemorandoLogic a = new Ba_MemorandoLogic();
            return a.ConsultarCatalogo(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getBa_Memorando/{id}")]
        public List<Ba_MemorandoModel> GetExp(string id)
        {
            Ba_MemorandoLogic a = new Ba_MemorandoLogic();
            return a.Consulta(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getBa_Memorando")]
        public List<Ba_MemorandoModel> GetAll()
        {
            Ba_MemorandoLogic a = new Ba_MemorandoLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("Ba_Memorandocreate")]
        public IHttpActionResult Post(Ba_MemorandoModel b)
        {
            Ba_MemorandoLogic a = new Ba_MemorandoLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("Ba_Memorandoupdate")]
        public IHttpActionResult Put(Ba_MemorandoModel b)
        {
            Ba_MemorandoLogic a = new Ba_MemorandoLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getBa_Memorandodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            Ba_MemorandoLogic a = new Ba_MemorandoLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}