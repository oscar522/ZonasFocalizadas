using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/AccountTable")]
    public class AccountTableController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("getAccountTableid/{id}")]
        public AccountTableModel Get(int id)
        {
            AccountTableLogic a = new AccountTableLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("getAccountTable")]
        public List<AccountTableModel> Get()
        {
            AccountTableLogic a = new AccountTableLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("AccountTablecreate")]
        public IHttpActionResult Post(AccountTableModel b)
        {
            AccountTableLogic a = new AccountTableLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Name)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("AccountTableupdate")]
        public IHttpActionResult Put(AccountTableModel b)
        {
            AccountTableLogic a = new AccountTableLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Name)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getAccountTabledelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            AccountTableLogic a = new AccountTableLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}