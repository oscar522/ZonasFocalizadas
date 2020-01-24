using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/ExpedienteDocumentos")]
    public class ExpedienteDocumentosController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getExpedienteDocumentos/{id}")]
        public ExpedienteDocumentosModel Get(int id)
        {
            ExpedienteDocumentosLogic a = new ExpedienteDocumentosLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getExpedienteDocumentosIdExpediente/{id}")]
        public List<ExpedienteDocumentosModel> GetIdExpediente(int id)
        {
            ExpedienteDocumentosLogic a = new ExpedienteDocumentosLogic();
            return a.ConsultarIdList(id);
        }

        [Authorize]
        [Route("getExpedienteDocumentosIdExpedienteIdDoc/{id}")]
        public List<ExpedienteDocumentosModel> GetIdExpedienteIdDoc(string id)
        {
            ExpedienteDocumentosLogic a = new ExpedienteDocumentosLogic();
            return a.ConsultarIdExpIdDocList(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getExpedienteDocumentos")]
        public List<ExpedienteDocumentosModel> Get()
        {
            ExpedienteDocumentosLogic a = new ExpedienteDocumentosLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("ExpedienteDocumentoscreate")]
        public IHttpActionResult Post(ExpedienteDocumentosModel b)
        {
            ExpedienteDocumentosLogic a = new ExpedienteDocumentosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("ExpedienteDocumentosupdate")]
        public IHttpActionResult Put(ExpedienteDocumentosModel b)
        {
            ExpedienteDocumentosLogic a = new ExpedienteDocumentosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getExpedienteDocumentosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            ExpedienteDocumentosLogic a = new ExpedienteDocumentosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}