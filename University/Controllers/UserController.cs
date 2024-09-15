using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using University.API.Model;
using University.API.Queries;

namespace University.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserQueries userQuery) : ControllerBase
    {
        private IUserQueries UserQuery { get; } = userQuery;

        [HttpGet("all", Name = "GetAllUsers")]
        [EnableCors("MyAllowAll")]
        public IEnumerable<User> GetAll()
        {
            return null;
        }
    }
}
