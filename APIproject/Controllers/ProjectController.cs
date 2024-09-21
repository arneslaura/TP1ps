using Application.Exception;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIproject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _PServices;
        public ProjectController(IProjectServices PServices)
        {
            _PServices = PServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProjectDataResponse>), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> GetPD(string? name, int? campaign, int? client, int? offset, int? size)
        {
            try
            {
                var result = await _PServices.GetProjectsData(name, campaign, client, offset, size);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProjectResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> CreateP(ProjectRequest request)
        {
            try
            {
                var result = await _PServices.CreateProject(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (NotFoundException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (AlredyExistException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        public async Task<IActionResult> GetPById(Guid id)
        {
            try
            {
                var result = await _PServices.GetProjectById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (NotFoundException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpPatch("{id}/interactions")]
        [ProducesResponseType(typeof(List<InteractionsResponse>), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> AddI(Guid id, InteractionRequest request)
        {
            try
            {
                var result = await _PServices.AddInteractionToTheProject(id, request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (NotFoundException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPatch("{id}/tasks")]
        [ProducesResponseType(typeof(List<TasksResponse>), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> AddT(Guid id, TasksRequest request)
        {
            try
            {
                var result = await _PServices.AddTaskToTheProject(id, request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (NotFoundException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("/api/v1/Tasks/{id}")]
        [ProducesResponseType(typeof(List<TasksResponse>), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> UpdateT(Guid id, TasksRequest request)
        {
            try
            {
                var result = await _PServices.UpdateTaskToTheProject(id, request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (NotFoundException ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
