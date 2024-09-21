using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class ClientCommand : IClientCommand
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public ClientCommand(AppDbContext context)
        {
            _context = context;
        }

        //create
        public async Task<Client> CreateClient(Client c)
        {
            _context.Client.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }


    }
}
