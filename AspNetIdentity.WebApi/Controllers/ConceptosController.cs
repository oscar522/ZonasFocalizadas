using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Concepto")]
    public class ConceptosController : ApiController
    {
        [Authorize]
        [Route("getConceptoid/{id}")]
        public ConceptoModel Get(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getConcepto")]
        public List<ConceptoModel> GetS()
        {
            ConceptoLogic a = new ConceptoLogic();
            var model = new List<ConceptoModel>();
                model = a.Consulta();
            return model;
        }

        [HttpPost]
        [Authorize]
        [Route("Conceptocreate")]
        public IHttpActionResult Post(ConceptoModel b)
        {
            ConceptoLogic a = new ConceptoLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("Conceptoupdate")]
        public IHttpActionResult Put(ConceptoModel b)
        {
            ConceptoLogic a = new ConceptoLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getConceptodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            string resul = a.Eliminar(id);
            return resul;
        }

        [Authorize]
        [Route("getConceptoTU")]
        public List<CtDeptoModel> GeTU()
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaTipoUsuario();
        }

        ////[Authorize]
        //[Route("getConceptoU")]
        //public List<CtDeptoModel> GeUyyyy()
        //{
        //   string  id = "1";
        //    ConceptoLogic a = new ConceptoLogic();
        //    return a.ConsultaUsuario(id);
        //}

        [Authorize]
        [Route("getConceptoU/{id}")]
        public List<CtDeptoModel> GetCausa2(string id)
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaUsuario(id);
        }

        [Authorize]
        [Route("getConceptoCausa")]
        public List<CtDeptoModel> GetCausa()
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaTipoCausa();
        }

    }
}