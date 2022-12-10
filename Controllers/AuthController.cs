using EmployeeAPI.Models;
using EmployeeAPI.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("Auth/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _authServices.RegisterAsync(model);

            // if not registered == not authenticated
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
