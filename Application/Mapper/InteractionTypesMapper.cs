using Application.Interfaces;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class InteractionTypesMapper : IInteractionTypesMapper
    {
        //mapeo de lista de InteractionTypes a lista de GenericResponse
        public Task<List<GenericResponse>> GetAllInteractionTypesResponse(List<InteractionTypes> InteractionTypes)
        {
            List<GenericResponse> lista = new List<GenericResponse>();
            foreach (var it in InteractionTypes)
            {
                var response = new GenericResponse
                {
                    Id = it.Id,
                    Name = it.Name,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }
        //mapeo de InteractionType a GenericResponse
        public Task<GenericResponse> GetInteractionTypesResponse(InteractionTypes it)
        {
            var response = new GenericResponse
            {
                Id = it.Id,
                Name = it.Name,
            };
            return Task.FromResult(response);
        }
    }
}
