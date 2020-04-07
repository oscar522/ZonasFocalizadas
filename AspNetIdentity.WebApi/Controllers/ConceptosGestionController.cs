using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;
using System;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/ConceptoGestion")]
    public class ConceptosGestionController : ApiController
    {
       
        #region Gestion

        [Authorize]
        [Route("getConceptosGestionid/{id}")]
        public ConceptoGestionModel Get(int id)
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getConceptosGestion")]
        public List<ConceptoGestionModel> GetId()
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            var model = new List<ConceptoGestionModel>();
            model = a.Consulta();
            return model;
        }

        [Authorize]
        [Route("getConceptosGestionIdConcepto/{id}")]
        public List<ConceptoGestionModel> GetIdConcepto( string Id)
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            var model = new List<ConceptoGestionModel>();
            model = a.ConsultaIdConcepto(Convert.ToInt32(Id));
            return model;
        }

        [HttpPost]
        [Authorize]
        [Route("ConceptosGestioncreate")]
        public IHttpActionResult Post(ConceptoGestionModel b)
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("ConceptosGestionupdate")]
        public IHttpActionResult Put(ConceptoGestionModel b)
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getConceptosGestiondelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            string resul = a.Eliminar(id);
            return resul;
        }

        #endregion

        [Authorize]
        [Route("getConsultaEstados")]
        public List<ConceptoEstadoModel> GetEstados()
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            var model = new List<ConceptoEstadoModel>();
            model = a.ConsultaEstados();
            return model;
        }

        [Authorize]
        [Route("getConceptoTipoSoporte")]
        public List<ConceptoTipoSoporteModel> GetTipoSoporte()
        {
            ConceptoGestionLogic a = new ConceptoGestionLogic();
            var model = new List<ConceptoTipoSoporteModel>();
            model = a.ConsultaSoportes();
            return model;
        }


    }
}