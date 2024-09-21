using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICampaignTypeMapper
    {
        Task<List<GenericResponse>> GetAllCampaignTypesResponse(List<CampaignType> CampaignTypes);
        Task<GenericResponse> GetCampaignTypeResponse(CampaignType ct);
    }
}
