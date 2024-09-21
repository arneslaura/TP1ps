using Application.Interfaces;
using Application.Response;

namespace Application.UseCases
{
    public class CampaignTypeServices : ICampaignTypeServices
    {
        private readonly ICampaignTypeQuery _query;
        private readonly ICampaignTypeMapper _mapper;
        public CampaignTypeServices(ICampaignTypeQuery query, ICampaignTypeMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //get all
        public async Task<List<GenericResponse>> GetAllCampaignTypes()
        {
            var list = await _query.ReadAllCampaignTypes();
            return await _mapper.GetAllCampaignTypesResponse(list);
        }
        // get by id
        public async Task<GenericResponse> GetCampaignTypeById(int id)
        {
            var ct = await _query.ReadCampaignTypeById(id);
            return await _mapper.GetCampaignTypeResponse(ct);
        }
    }
}
