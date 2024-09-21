using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface ITasksService
    {
        Task<TasksResponse> CreateTask(Guid projectId, TasksRequest request);
        Task<List<TasksResponse>> GetAllTasksByProjectId(Guid projectId);
        Task<TasksResponse> UpdateTasks(Guid projectId, TasksRequest request);
    }
}
