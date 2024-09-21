using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionTypesMapper
    {
        Task<List<GenericResponse>> GetAllInteractionTypesResponse(List<InteractionTypes> InteractionTypes);
        Task<GenericResponse> GetInteractionTypesResponse(InteractionTypes it);
    }
}
