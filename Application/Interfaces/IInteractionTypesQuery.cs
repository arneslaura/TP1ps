using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionTypesQuery
    {
        Task<List<InteractionTypes>> ReadAllInteractionTypes();
        Task<InteractionTypes?> ReadInteractionTypesById(int id);
    }
}
