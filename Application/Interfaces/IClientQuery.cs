using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientQuery
    {
        Task<List<Client>> ReadAllClients();
        Task<Client?> ReadClientById(int id);
    }
}
