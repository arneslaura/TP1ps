using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIproject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaignTypeController : ControllerBase
    {
        private readonly ICampaignTypeServices _CTServices;
        public CampaignTypeController(ICampaignTypeServices CTServices)
        {
            _CTServices = CTServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
        public async Task<IActionResult> GetAllCT()
        {
            var result = await _CTServices.GetAllCampaignTypes();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
