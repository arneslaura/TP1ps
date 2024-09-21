using Application.Response;

namespace Application.Interfaces
{
    public interface ICampaignTypeServices
    {
        Task<List<GenericResponse>> GetAllCampaignTypes();
        Task<GenericResponse> GetCampaignTypeById(int id);
    }
}
