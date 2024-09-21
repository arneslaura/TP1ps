using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectMapper
    {
        Task<Project> CreateP(ProjectRequest request);
        Task<ProjectResponse> GetProjectResponse(Project p);
    }
}
