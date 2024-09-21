using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIproject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusServices _TTServices;
        public TaskStatusController(ITaskStatusServices TTServices)
        {
            _TTServices = TTServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
        public async Task<IActionResult> GetAllTS()
        {
            var result = await _TTServices.GetAllTaskStatus();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
