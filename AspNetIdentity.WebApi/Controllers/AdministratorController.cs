using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;
using AspNetIdentity.WebApi.Models;
using System;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Administrator")]
    public class AdministratorController : ApiController
    {
        [Authorize]
        [Route("getConsultarGestion/{id}")]
        public List<PlGestionUsersModel> GetGestion(string id)
        {
            string[] TypesAndaDate = id.Split('_');
            AdministratorLogic a = new AdministratorLogic();
            return a.ConsultarGestion(TypesAndaDate[0], TypesAndaDate[1], TypesAndaDate[2], TypesAndaDate[3], Convert.ToInt32(TypesAndaDate[4]), TypesAndaDate[5]);
        }

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
        [Route("getResumenAll/{IdP}")]
        public List<ResumenTipificacionAllModel> GetRegumenAll(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<ResumenTipificacionAllModel>();
            model = a.ConsultarResumenAll(IdP);
            return model;
        }
        // CaracterizacionJuridicaAll
        [Authorize]
        [Route("GetRegumenCaracterizacionJuridicaAll/{IdP}")]
        public List<CaracterizacionJuridicaResumenModel> GetRegumenCaracterizacionJuridicaAll(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<CaracterizacionJuridicaResumenModel>();
            model = a.ConsultarResumenCaracterizacionJuridicaAll(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenListaRegumenCaracterizacionJuridica/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaRegumenCaracterizacionJuridica(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaResumenCaracterizacionJuridica(IdP);
            return model;
        }

        //

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
        [Route("getResumenListaAll/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaAll(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaAll(IdP);
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
        [Route("getResumenListaPlanoAll/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaPlanoAll(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaPlanoAll(IdP);
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
        [Route("getResumenRegistroAll/{IdP}")]
        public List<ResumenTipificacionAllModel> GetRegumenRegistroAll(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<ResumenTipificacionAllModel>();
            model = a.ConsultarResumenRegistroAll(IdP);
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
        [Route("getAdministratorCountDeptoMuni")]
        public List<CtCiudadModel> GetCountMuni()
        {
            AdministratorLogic a = new AdministratorLogic();
            List<CtCiudadModel> model = a.ConsultarIdPCountDeptoMuni();
            return model;
        }

        [Authorize]
        [Route("getAdministratorCountDepto")]
        public List<CtCiudadModel> GetCountDeptos()
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

        [Authorize]
        [Route("getResumenListaSinPlano/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaSinPlano(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaSinPlano(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenListaSinPlanoAll/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaSinPlanoAll(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaSinPlanoAll(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenListaConPlano/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaConPlano(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaConPlano(IdP);
            return model;
        }

        [Authorize]
        [Route("getResumenListaConPlanoAll/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetRegumenListaConPlanoAll(string IdP)
        {
            AdministratorLogic a = new AdministratorLogic();
            var model = new List<BaldiosPersonaNaturalModel>();
            model = a.ConsultarResumenListaConPlanoAll(IdP);
            return model;
        }


    }
}