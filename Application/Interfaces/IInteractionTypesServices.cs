using Application.Response;

namespace Application.Interfaces
{
    public interface IInteractionTypesServices
    {
        Task<List<GenericResponse>> GetAllInteractionTypes();
        Task<GenericResponse> GetInteractionTypesById(int id);
    }
}
