using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/BaldiosPersonaNatural")]
    public class BaldiosPersonaNaturalController : ApiController
    {
        [Authorize]
        [Route("getBaldiosPersonaNaturalid/{id}")]
        public BaldiosPersonaNaturalModel Get(int id)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getBaldiosPersonaNatural/{IdP}")]
        public List<BaldiosPersonaNaturalModel> Get(string IdP)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            if (IdP.Equals("0") || IdP.Equals("") || IdP is null)
            {
                model = a.Consulta();
            }
            else
            {
                model = a.ConsultarIdP(IdP);
            }
            return model;
        }

        [Authorize]
        [Route("getBaldiosPersonaNaturalUser/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetUser(string IdP)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarIdPUser(IdP);
            return model;
        }

        [Authorize]
        [Route("getBaldiosPersonaNaturalUserMal/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetUserMal(string IdP)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarIdPUserMal(IdP);
            return model;
        }

        [Authorize]
        [Route("getBaldiosPersonaNaturalCount/{IdP}")]
        public int GetCount(string IdP)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            int model = a.ConsultarIdPCount(IdP);
            return model;
        }

        [Authorize]
        [Route("getBaldiosPersonaNaturalCountEdit/{IdP}")]
        public int GetCountEdit(string IdP)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            int model = a.ConsultarIdPCountEdit(IdP);
            return model;
        }

        [Authorize]
        [Route("getBaldiosPersonaNaturalCountMal/{IdP}")]
        public int GetCountMal(string IdP)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            int model = a.ConsultarIdPCountMal(IdP);
            return model;
        }

        [Authorize]
        [Route("getBaldiosPersonaNatural")]
        public List<BaldiosPersonaNaturalModel> GetS()
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
                model = a.Consulta();
            return model;
        }

        [HttpPost]
        [Authorize]
        [Route("BaldiosPersonaNaturalcreate")]
        public IHttpActionResult Post(BaldiosPersonaNaturalModel b)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NumeroExpediente)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("BaldiosPersonaNaturalupdate")]
        public IHttpActionResult Put(BaldiosPersonaNaturalModel b)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NumeroExpediente)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getBaldiosPersonaNaturaldelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            string resul = a.Eliminar(id);
            return resul;
        }

        [Authorize]
        [Route("getBaldiosPersonaNaturalBuscarArchivos/{id}")]
        [HttpDelete]
        public string BuscarArchivos(int id)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            string resul = a.BuscarArchivos(id);
            return resul;
        }

        [HttpPost]
        [Authorize]
        [Route("BaldiosPersonaNaturalUpdateArchivoVerificado")]
        public IHttpActionResult PostUpdateEstatusArchivoVerificado(CtGeneroModel b)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var result = a.UpdateEstatusArchivoVerificado(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [Route("BaldiosPersonaNaturalUpdateEstatusCaracterizacion")]
        public IHttpActionResult PostUpdateEstatusEstadoCaracterizacion(CtGeneroModel b)
        {
            BaldiosPersonaNaturalLogic a = new BaldiosPersonaNaturalLogic();
            var result = a.UpdateEstatusEstadoCaracterizacion(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

    }
}