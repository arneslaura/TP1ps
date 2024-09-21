using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITasksCommand
    {
        Task<Tasks> CreateTask(Tasks t);
        Task<Tasks> UpdateTask(Tasks t);
    }
}
