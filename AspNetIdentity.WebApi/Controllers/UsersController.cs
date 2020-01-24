using AspNetIdentity.WebApi.Logic;
using AspNetIdentity.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseApiController
    {
        private UsersLogic usersLogic;

        public UsersController()
        {
            usersLogic = new UsersLogic();
        }

        [Authorize(Roles = "Manager")]
        [Route("getusers/{id}", Name = "GetUsers")]
        public async Task<IHttpActionResult> GetUsers(int Id)
        {
            string result = await Task.Run(() => usersLogic.GetUsersByAccountId(Id));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Authorize(Roles = "Manager")]
        [Route("getuser/{id}", Name = "GetUser")]
        public async Task<IHttpActionResult> GetUserById(int Id)
        {
            string result = await Task.Run(() => usersLogic.GetUserById(Id));

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Authorize(Roles = "Manager")]
        [Route("updateuser", Name = "UpdateUser")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser(PutUsersBindingModel putUsersBindingModel)
        {
            bool result = await Task.Run(() => usersLogic.UpdateUser(putUsersBindingModel));

            if (result)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Authorize(Roles = "Manager")]
        [Route("deleteuser/{id}", Name = "DeleteUser")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int Id)
        {
            bool result = await Task.Run(() => usersLogic.DeleteUser(Id));

            if (result)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}