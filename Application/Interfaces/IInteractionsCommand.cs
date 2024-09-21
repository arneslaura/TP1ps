using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionsCommand
    {
        Task<Interactions> CreateInteraction(Interactions i);
    }
}
