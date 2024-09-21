using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICampaignTypeQuery
    {
        Task<List<CampaignType>> ReadAllCampaignTypes();
        Task<CampaignType?> ReadCampaignTypeById(int id);
    }
}
