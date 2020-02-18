using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using System;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/Registro")]
    public class RegistroController : ApiController
    {
        [Authorize]
        [Route("getRegistroid/{id}")]
        public List<RegistroModel> Get(string id)
        {
            var model = new List<RegistroModel>();
            if (!id.Equals("")) {
                RegistroLogic a = new RegistroLogic();
                model=  a.Consulta(id);
            }
           
            return model;
        }

        [Authorize]
        [Route("getRegistroidRevisados/{id}")]
        public List<RegistroModel> GetRevisados(string id)
        {
            var model = new List<RegistroModel>();
            if (!id.Equals(""))
            {
                RegistroLogic a = new RegistroLogic();
                model = a.ConsultaRevisados(id);
            }

            return model;
        }

        [Authorize]
        [Route("getRegistroidExp/{id}")]
        public RegistroModel Getid(string id)
        {
            long IdRegistro = Convert.ToInt64(id);
            var model = new RegistroModel();
            if (!id.Equals(""))
            {
                RegistroLogic a = new RegistroLogic();
                model = a.ConsultaId(IdRegistro);
            }

            return model;
        }

        //[Authorize]
        //[Route("getRegistro/{IdP}")]
        //public List<RegistroModel> Get(string IdP)
        //{
        //    RegistroLogic a = new RegistroLogic();
        //    var model = new List<RegistroModel>();
        //    if (IdP.Equals("0") || IdP.Equals("") || IdP is null)
        //    {
        //        model = a.Consulta();
        //    }
        //    else {
        //        model = a.ConsultarIdP(IdP);
        //    }
        //    return model;
        //}

        //[Authorize]
        //[Route("getRegistro")]
        //public List<RegistroModel> Get()
        //{
        //    RegistroLogic a = new RegistroLogic();
        //    var model = new List<RegistroModel>();
        //        model = a.Consulta();
        //    return model;
        //}

        [HttpPost]
        [Authorize]
        [Route("Registrocreate")]
        public IHttpActionResult Post(RegistroModel b)
        {
            RegistroLogic a = new RegistroLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Matricula)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("Registroupdate")]
        public IHttpActionResult Put(RegistroModel b)
        {
            RegistroLogic a = new RegistroLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getRegistrodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            RegistroLogic a = new RegistroLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}