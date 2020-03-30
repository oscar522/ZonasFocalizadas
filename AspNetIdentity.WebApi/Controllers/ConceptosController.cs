using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;
using System;

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
        [Route("getConceptoUC/{id}")]
        public List<ConceptoModel> GetConceptosAsociados(string id)
        {
            ConceptoLogic a = new ConceptoLogic();
            int IdConcepto = Convert.ToInt32(id);
            return a.ConsultaUsuarioConcepto(IdConcepto);
        }
        [Authorize]
        [Route("getConceptoUCD/{id}")]
        public string GetConceptosAsociadosD(string id)
        {
            ConceptoLogic a = new ConceptoLogic();
            int IdConcepto = Convert.ToInt32(id);
            var res =  a.EliminarAsociado(IdConcepto);
            return res;
        }

        [Authorize]
        [Route("getConceptoCausa")]
        public List<CtDeptoModel> GetCausa()
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaTipoCausa();
        }
        #region soportes
        [HttpPost]
        [Authorize]
        [Route("ConceptoCrearDocumentoSoporte")]
        public IHttpActionResult PostCrearDocumentoSoporte(ConceptoModel b)
        {
            ConceptoLogic a = new ConceptoLogic();
            var result = a.CrearDocumentoSoporte(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }
        [Authorize]
        [Route("getConceptoConsultaDocumentoSoporte/{id}")]
        public List<CtPaisModel> GetConsultaDocumentoSoporte(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaDocumentoSoporte(id);
        }
        [Authorize]
        [Route("getConceptoDeleteDocumentoSoporte/{id}")]
        [HttpDelete]
        public string DeleteDocumentoSoporte(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            string resul = a.DeleteDocumentoSoporte(id);
            return resul;
        }
        #endregion
        #region anexo
        [HttpPost]
        [Authorize]
        [Route("ConceptoCrearDocumentoAnexo")]
        public IHttpActionResult PostCrearDocumentoAnexo(ConceptoModel b)
        {
            ConceptoLogic a = new ConceptoLogic();
            var result = a.CrearDocumentoAnexo(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }
        [Authorize]
        [Route("getConceptoConsultaDocumentoAnexo/{id}")]
        public List<CtPaisModel> GetConsultaDocumentoAnexo(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaDocumentoAnexo(id);
        }
        [Authorize]
        [Route("getConceptoDeleteDocumentoAnexo/{id}")]
        [HttpDelete]
        public string DeleteDocumentoAnexo(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            string resul = a.DeleteDocumentoAnexo(id);
            return resul;
        }

        #endregion
        #region expediente
        [HttpPost]
        [Authorize]
        [Route("ConceptoCrearExpediente")]
        public IHttpActionResult PostCrearExpediente(ConceptoModel b)
        {
            ConceptoLogic a = new ConceptoLogic();
            var result = a.CrearExpediente(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }
        [Authorize]
        [Route("getConceptoConsultaExpediente/{id}")]
        public BaldiosPersonaNaturalModel GetConsultaExpediente(string id)
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaExpediente(id);
        }
        [Authorize]
        [Route("getConceptoConsultaExpedientesAsociados/{id}")]
        public List<CtPaisModel> GetConsultaExpedientesAsociados(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaExpedientesAsociados(id);
        }
        [Authorize]
        [Route("getConceptoDeleteExpediente/{id}")]
        [HttpDelete]
        public string DeleteExpediente(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            string resul = a.DeleteExpediente(id);
            return resul;
        }
        #endregion
        #region UsuariosAsociados
        [HttpPost]
        [Authorize]
        [Route("ConceptoCrearUsuariosAsociados")]
        public IHttpActionResult PostCrearUsuariosAsociados(ConceptoModel b)
        {
            ConceptoLogic a = new ConceptoLogic();
            var result = a.CrearUsuariosAsociados(b);
            if (!string.IsNullOrEmpty(result.ToString())) return Ok(result);
            return NotFound();
        }
        
        [Authorize]
        [Route("getConceptoConsultaUsuariosAsociados/{id}")]
        public List<ConceptoModel> GetConsultaUsuariosAsociados(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            return a.ConsultaUsuariosAsociados(id);
        }
        [Authorize]
        [Route("getConceptoDeleteUsuariosAsociados/{id}")]
        [HttpDelete]
        public string DeleteUsuariosAsociados(int id)
        {
            ConceptoLogic a = new ConceptoLogic();
            string resul = a.DeleteUsuariosAsociados(id);
            return resul;
        }
        #endregion


    }
}