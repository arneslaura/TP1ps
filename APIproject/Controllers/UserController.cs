using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIproject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _UServices;
        public UserController(IUserServices UServices)
        {
           _UServices = UServices;  
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponse>), 200)]
        public async Task<IActionResult> GetAllU()
        {
            var result = await _UServices.GetAllUsers();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
