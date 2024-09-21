using Application.Interfaces;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class CampaignTypeMapper : ICampaignTypeMapper
    {
        //mapeo de lista de CampaignType a lista de GenericResponse
        public Task<List<GenericResponse>> GetAllCampaignTypesResponse(List<CampaignType> CampaignTypes)
        {
            List<GenericResponse> lista = new List<GenericResponse>();
            foreach (var ct in CampaignTypes)
            {
                var response = new GenericResponse
                {
                    Id = ct.Id,
                    Name=ct.Name,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }
        //mapeo de CampaignType a GenericResponse
        public Task<GenericResponse> GetCampaignTypeResponse(CampaignType ct)
        {
            var response = new GenericResponse
            {
                Id = ct.Id,
                Name = ct.Name,
            };
            return Task.FromResult(response);
        }
    }
}
