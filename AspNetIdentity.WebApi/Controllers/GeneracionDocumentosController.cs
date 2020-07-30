using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/GeneracionDocumentos")]
    public class GeneracionDocumentosController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getGeneracionDocumentosid/{id}")]
        public GeneracionDocumentosModel Get(int id)
        {
            GeneracionDocumentosLogic a = new GeneracionDocumentosLogic();
            return a.ConsultarId(id);
        }

        //[Authorize]
        //[Route("getGeneracionDocumentosCatalogoid/{id}")]
        //public List<GeneracionDocumentosCatalogosModel> GetCatalogo(int id)
        //{
        //    GeneracionDocumentosLogic a = new GeneracionDocumentosLogic();
        //    return a.ConsultarCatalogo(id);
        //}

        // GET api/values/
        [Authorize]
        [Route("getGeneracionDocumentos/{id}")]
        public List<BaldiosPersonaNaturalModel> GetExp(string id)
        {
            GeneracionDocumentosLogic a = new GeneracionDocumentosLogic();
            return a.Consulta(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getGeneracionDocumentos")]
        public List<CaracterizacionSolicitanteModel> GetAll()
        {
            GeneracionDocumentosLogic a = new GeneracionDocumentosLogic();
            return a.Consulta();
        }

        //[HttpPost]
        //[Authorize]
        //[Route("GeneracionDocumentoscreate")]
        //public IHttpActionResult Post(GeneracionDocumentosModel b)
        //{
        //    GeneracionDocumentosLogic a = new GeneracionDocumentosLogic();
        //    var result = a.Crear(b);
        //    if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
        //    return NotFound();
        //}

        [HttpPut]
        [Authorize]
        [Route("GeneracionDocumentosupdate")]
        public IHttpActionResult Put(GeneracionDocumentosModel b)
        {
            GeneracionDocumentosLogic a = new GeneracionDocumentosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getGeneracionDocumentosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            GeneracionDocumentosLogic a = new GeneracionDocumentosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}