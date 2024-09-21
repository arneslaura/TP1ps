using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITasksMapper
    {
        Task<Tasks> CreateT(Guid projectId, TasksRequest request);
        Task<List<TasksResponse>> GetAllTasksResponse(List<Tasks> Tasks);
        Task<TasksResponse> GetTaskResponse(Tasks t);
    }
}
