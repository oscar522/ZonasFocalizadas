using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;
using AspNetIdentity.WebApi.Models;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Administrator")]
    public class AdministratorController : ApiController
    {
        [Authorize]
        [Route("getAdministratorid/{id}")]
        public BaldiosPersonaNaturalModel Get(int id)
        {
            AdministratorLogic a = new AdministratorLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getAdministrator/{IdP}")]
        public List<BaldiosPersonaNaturalModel> Get(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
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
        [Route("getAdministratorUser/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetUser(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarIdPUser(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumen/{IdP}")]
        public List<ResumenTipificacionModel> GetRegumen(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<ResumenTipificacionModel>();
            model = a.ConsultarResumen(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenLista/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenLista(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenLista(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenListaPlano/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaPlano(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaPlano(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenRegistro/{IdP}")]
        public List<ResumenTipificacionModel> GetRegumenRegistro(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<ResumenTipificacionModel>();
            model = a.ConsultarResumenRegistro(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenRegistroLista/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenRegistroLista(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenRegistroLista(IdP);
            return model;
        }


        [Authorize]
        [Route("getAdministratorCountDeptos")]
        public List<CtCiudadModel> GetCount()
        {
            AdministratorLogic a = new AdministratorLogic();
            List<CtCiudadModel> model = a.ConsultarIdPCountDepto();
            return model;
        }

        [Authorize]
        [Route("getAdministratorCountEdit/{IdP}")]
        public int GetCountEdit(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            int model = a.ConsultarIdPCountEdit(IdP);
            return model;
        }

        [Authorize]
        [Route("getAdministrator")]
        public List<BaldiosPersonaNaturalModel> GetS()
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
                model = a.Consulta();
            return model;
        }

     
    }
}