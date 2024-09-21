using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientCommand
    {
        Task<Client> CreateClient(Client c);
    }
}
