using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteracionsMapper
    {
        Task<Interactions> CreateI(Guid projectId, InteractionRequest request);
        Task<List<InteractionsResponse>> GetAllInteractionsResponse(List<Interactions> Interactions);
        Task<InteractionsResponse> GetInteractionsResponse(Interactions i);
    }
}
