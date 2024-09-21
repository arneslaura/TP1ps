using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IProjectServices
    {
        Task<ProjectResponse> CreateProject(ProjectRequest request);
        Task<List<ProjectDataResponse>> GetProjectsData(string? name, int? ctId, int? cId, int? offset, int? size);
        Task<ProjectResponse> GetProjectById(Guid id);
        Task<InteractionsResponse> AddInteractionToTheProject(Guid projectId, InteractionRequest request);
        Task<TasksResponse> AddTaskToTheProject(Guid projectId, TasksRequest request);
        Task<TasksResponse> UpdateTaskToTheProject(Guid TaskId, TasksRequest request);
    }
}
