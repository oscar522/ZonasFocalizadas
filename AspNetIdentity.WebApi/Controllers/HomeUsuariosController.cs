using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/HomeUsuarios")]
    public class HomeUsuariosController : ApiController
    {
        [Authorize]
        [Route("getCountRegistroAsociados/{IdP}")]
        public int GetCount(string IdP)
        {
            HomeUsuariosLogic a = new HomeUsuariosLogic();
            int model = a.ConsultaCountRegistroUser(IdP);
            return model;
        }

        [Authorize]
        [Route("getCountRegistroAsociadosRevisados/{IdP}")]
        public int GetCountEdit(string IdP)
        {
            HomeUsuariosLogic a = new HomeUsuariosLogic();
            int model = a.ConsultaCountRegistroUserRevisados(IdP);
            return model;
        }

        [Authorize]
        [Route("getBuscarExpediente/{IdP}")]
        public List<BaldiosPersonaNaturalModel> GetBuscarExpediente(string IdP)
        {
            HomeUsuariosLogic a = new HomeUsuariosLogic();
            List<BaldiosPersonaNaturalModel> model = a.BuscaExpedientes(IdP);
            return model;
        }

        [Authorize]
        [Route("getRegistroIdExpediente/{IdP}")]
        public List<RegistroModel> GetRegistroIdExpediente(string IdP)
        {
            HomeUsuariosLogic a = new HomeUsuariosLogic();
            List<RegistroModel> model = a.RegistroIdExpediente(Convert.ToInt64(IdP));
            return model;
        }



        //BuscarExpediente

    }
}