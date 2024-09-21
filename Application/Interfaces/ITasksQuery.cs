using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITasksQuery
    {
        Task<List<Tasks>> ReadAllTasksByProjectId(Guid projectId);
        Task<Tasks?> ReadTaskById(Guid Id);
    }
}
