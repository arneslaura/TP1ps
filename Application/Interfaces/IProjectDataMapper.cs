using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectDataMapper
    {
        Task<List<ProjectDataResponse>> GetProjectDataResponse(List<Project> projects);
        Task<ProjectDataResponse> GetProjectDataResponse(Project p);
    }
}
