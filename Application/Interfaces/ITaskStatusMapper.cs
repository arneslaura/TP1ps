using Application.Response;

namespace Application.Interfaces
{
    public interface ITaskStatusMapper
    {
        Task<List<GenericResponse>> GetAllTaskStatusResponse(List<Domain.Entities.TaskStatus> TaskStatus);
        Task<GenericResponse> GetTaskStatusResponse(Domain.Entities.TaskStatus ts);
    }
}
