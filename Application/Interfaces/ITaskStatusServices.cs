using Application.Response;

namespace Application.Interfaces
{
    public interface ITaskStatusServices
    {
        Task<List<GenericResponse>> GetAllTaskStatus();
        Task<GenericResponse> GetTaskStatusById(int id);
    }
}
