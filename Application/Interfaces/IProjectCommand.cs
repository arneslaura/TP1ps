using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectCommand 
    {
        Task<Project> CreateProject(Project p);
        System.Threading.Tasks.Task UpdateProject(Project p);
    }
}
