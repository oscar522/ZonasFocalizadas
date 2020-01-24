using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;
using System;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/userdata")]
    public class UserDataController : ApiController
    {
        [Authorize]
        [Route("getuserdataid/{id}")]
        public UserDataModel Get(string id)
        {
            UserDataLogic a = new UserDataLogic();
            return a.ConsultarId(id);
        }
        [Authorize]
        [Route("getuserdataidhash/{id}")]
        public UserDataModel GetHash(string id)
        {
            UserDataLogic a = new UserDataLogic();
            return a.ConsultarIdHash(id);
        }
        [Authorize]
        [Route("progreso/{id}")]
        public Int32 Get(int id)
        {
            UserDataLogic a = new UserDataLogic();
            return a.ConsultarProgreso(id);
        }
        [Authorize]
        [Route("progresoIndex/{id}")]
        public Int32 Get2(int id)
        {
            UserDataLogic a = new UserDataLogic();
            return a.ConsultarProgresoIndex(id);
        }

        //[Authorize(Roles = "Administrator")]
        //[Route("getuserdata")]
        //public List<UserDataModel> Get()
        //{
        //    HvCtCargoLogic a = new HvCtCargoLogic();
        //    return a.Consulta();
        //}

        //[HttpPost]
        //[Authorize(Roles = "Administrator")]
        //[Route("userdatacreate")]
        //public IHttpActionResult Postuserdatacreate(UserDataModel HvCtCargo)
        //{
        //    HvCtCargoLogic a = new HvCtCargoLogic();
        //    var result = a.Crear(HvCtCargo);
        //    if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
        //    return NotFound();
        //}

        //[HttpPut]
        //[Authorize(Roles = "Administrator")]
        //[Route("userdataupdate")]
        //public IHttpActionResult Putuserdataupdate(UserDataModel HvCtCargo)
        //{
        //    HvCtCargoLogic a = new HvCtCargoLogic();
        //    var result = a.Actualizar(HvCtCargo);
        //    if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
        //    return NotFound();
        //}

        //[Authorize(Roles = "Administrator")]
        //[Route("getuserdatadelete/{id}")]
        //[HttpDelete]
        //public string Delete(int id)
        //{
        //    HvCtCargoLogic a = new HvCtCargoLogic();
        //    string resul = a.Eliminar(id);
        //    return resul;
        //}
    }
}