using System;

namespace Application.Interfaces
{
    public interface ITaskStatusQuery
    {
        Task<List<Domain.Entities.TaskStatus>> ReadAllTaskStatus();
        Task<Domain.Entities.TaskStatus?> ReadTaskStatusById(int id);
    }
}
