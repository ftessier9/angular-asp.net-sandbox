using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using asp_core_sandbox.Services;
using asp_core_sandbox.Models;

namespace asp_core_sandbox.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private IConfiguration configuration;

        public UserController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        [HttpGet("{userId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult GetUserInfoById(int userId)
        {
            try
            {
                UserService tableService = new UserService(configuration);
                return Ok(tableService.GetUserInfoById(userId));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost()]
        [ApiExplorerSettings(GroupName ="v1")]
        public IActionResult createUser([FromBody] UserInfo newUser)
        {
            try
            {
                UserService tableService = new UserService(configuration);
                return Ok(tableService.createUser(newUser));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught:", e);
                return BadRequest(e.Message);
            }
        }
    }
}
