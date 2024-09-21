using Application.Interfaces;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class ProjectDataMapper : IProjectDataMapper
    {
        private readonly IClientServices _cServices;
        private readonly ICampaignTypeServices _cTServices;

        public ProjectDataMapper(IClientServices cServices, ICampaignTypeServices cTServices) { 
            _cServices = cServices;
            _cTServices = cTServices;
        }

        //mapeo de lista de Projects a lista de ProjectDataResponse
        public async Task<List<ProjectDataResponse>> GetProjectDataResponse(List<Project> projects)
        {
            List<ProjectDataResponse> lista = new List<ProjectDataResponse>();
            foreach (var p in projects)
            {
                var response = new ProjectDataResponse
                {
                    Id = p.ProjectID,
                    Name = p.ProjectName,
                    Start = p.StartDate,
                    End = p.EndDate,
                    Client = await _cServices.GetClientById(p.ClientID),
                    CampaignType = await _cTServices.GetCampaignTypeById(p.CampaignType),
                };
                lista.Add(response);
            }
            return lista;
        }
        //mapeo de Project a ProjectDataResponse
        public async Task<ProjectDataResponse> GetProjectDataResponse(Project p)
        {
            var response = new ProjectDataResponse
            {
                Id = p.ProjectID,
                Name = p.ProjectName,
                Start = p.StartDate,
                End= p.EndDate,
                Client = await _cServices.GetClientById(p.ClientID),
                CampaignType = await _cTServices.GetCampaignTypeById(p.CampaignType),
            };
            return response;
        }
    }
}
