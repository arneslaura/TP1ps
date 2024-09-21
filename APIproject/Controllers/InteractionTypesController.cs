using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIproject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypesController : ControllerBase
    {
        private readonly IInteractionTypesServices _ITServices;
        public InteractionTypesController(IInteractionTypesServices ITServices)
        {
            _ITServices = ITServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
        public async Task<IActionResult> GetAllIT()
        {
            var result = await _ITServices.GetAllInteractionTypes();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
