using boilerplate.Controllers.Api.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace boilerplate.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost("/login")]
        public IActionResult Login(LoginModel model)
        {
            return Ok();
        }
    }
}
