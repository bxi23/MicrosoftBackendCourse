using Microsoft.AspNetCore.Mvc;
using SwaggerLab_ApiClientLab.Models;

namespace SwaggerLab_ApiClientLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();

        //Set up a simple GetUser endpoint that will accept a user ID and return sample JSON User detail.
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<User> GetUser(int id)
        {
            var user = new User{
                Id = id,
                Name = $"User {id}"
            };

            return Ok(user);
        }
    }
}