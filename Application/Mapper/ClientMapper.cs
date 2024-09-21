using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class ClientMapper : IClientMapper
    {
        //mapeo de ClientRequest a Client
        public Task<Client> CreateC(ClientRequest request)
        {
            var client = new Client
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Company = request.Company,
                Address = request.Address,
                CreateDate = DateTime.Now,
            };
            return Task.FromResult(client);
        }
        //mapeo de lista de Client a lista de ClientResponse
        public Task<List<ClientResponse>> GetAllClientsResponse(List<Client> Clients)
        {
            List<ClientResponse> lista = new List<ClientResponse>();
            foreach (var c in Clients)
            {
                var response = new ClientResponse
                {
                    Id = c.ClientID,
                    Name = c.Name,
                    Email = c.Email,
                    Company = c.Company,
                    Phone = c.Phone,
                    Address = c.Address,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }
        //mapeo de Client a ClientResponse
        public Task<ClientResponse> GetClientResponse(Client c)
        {
            var response = new ClientResponse
            {
                Id = c.ClientID,
                Name = c.Name,
                Email = c.Email,
                Company = c.Company,
                Phone = c.Phone,
                Address = c.Address,
            };
            return Task.FromResult(response);
        }
    }
}
