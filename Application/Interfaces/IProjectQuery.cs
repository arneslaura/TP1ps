using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectQuery
    {
        Task<List<Project>> ReadAllProjectsData(string? name, int? ctId, int? cId, int? offset = 0, int? size = 10);
        Task<Project?> ReadProjectById(Guid projectId);
        Task<Project?> ReadProjectByName(string name);
    }
}
