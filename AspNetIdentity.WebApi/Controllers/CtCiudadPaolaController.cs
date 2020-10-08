using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/CiudadPaola")] // localhost/api/CiudadPaola/GetCiudadPaola/sdfsd
    public class CtCiudadPaolaController : ApiController
    {
        //[Authorize]
        [Route("GetCiudadPaola/{id}")]
        public List<CtCiudadPaolaModel> Get(int id)
        {
            CtCiudadPaolaLogic a = new CtCiudadPaolaLogic();
            return a.ConsultarId(id);
        }

        //[Route("gethvctciudad/{IdP}")]
        //public List<CtCiudadModel> Get(string IdP)
        //{
        //    CtCiudadLogic a = new CtCiudadLogic();
        //    var model = new List<CtCiudadModel>();
        //    if (IdP.Equals("0") || IdP.Equals("") || IdP is null)
        //    {
        //        model = a.Consulta();
        //    }
        //    else
        //    {
        //        model = a.ConsultarIdP(IdP);
        //    }
        //    return model;
        //}

        //[Authorize]
        //[Route("gethvctciudad")]
        //public List<CtCiudadModel> GetS()
        //{
        //    CtCiudadLogic a = new CtCiudadLogic();
        //    var model = new List<CtCiudadModel>();
        //        model = a.Consulta();
        //    return model;
        //}

        [HttpPost]
        //[Authorize]
        [Route("PostCiudadPaola")]
        public IHttpActionResult Post(CtCiudadPaolaModel b)
        {
            CtCiudadPaolaLogic a = new CtCiudadPaolaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Nombre)) return Ok(result);
            return NotFound();
        }

        //[HttpPut]
        //[Authorize]
        //[Route("hvctciudadupdate")]
        //public IHttpActionResult Put(CtCiudadModel b)
        //{
        //    CtCiudadLogic a = new CtCiudadLogic();
        //    var result = a.Actualizar(b);
        //    if (!string.IsNullOrEmpty(result.Nombre)) return Ok(result);
        //    return NotFound();
        //}

        //[Authorize]
        //[Route("gethvctciudaddelete/{id}")]
        //[HttpDelete]
        //public string Delete(int id)
        //{
        //    CtCiudadLogic a = new CtCiudadLogic();
        //    string resul = a.Eliminar(id);
        //    return resul;
        //}
    }
}