using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IClientServices
    {
        Task<ClientResponse> CreateClient(ClientRequest request);
        Task<List<ClientResponse>> GetAllClients();
        Task<ClientResponse> GetClientById(int id);
    }
}
