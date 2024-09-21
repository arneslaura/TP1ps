using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IInteractionsService
    {
        Task<InteractionsResponse> CreateInteraction(Guid projectId, InteractionRequest request);
        Task<List<InteractionsResponse>> GetAllInteractionsByProjectId(Guid projectId);
    }
}
