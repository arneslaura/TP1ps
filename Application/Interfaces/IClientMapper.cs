using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientMapper
    {
        Task<Client> CreateC(ClientRequest request);
        Task<List<ClientResponse>> GetAllClientsResponse(List<Client> Clients);
        Task<ClientResponse> GetClientResponse(Client c);
    }
}
