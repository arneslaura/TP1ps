using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class InteractionsCommand : IInteractionsCommand
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public InteractionsCommand(AppDbContext context)
        {
            _context = context;
        }

        //create
        public async Task<Interactions> CreateInteraction(Interactions i)
        {
            _context.Interactions.Add(i);
            await _context.SaveChangesAsync();
            return i;
        }
    }
}
