using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;

namespace Infrastructure.Query
{
    public class ClientQuery : IClientQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public ClientQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all
        public async Task<List<Client>> ReadAllClients()
        {
            return await _context.Client.ToListAsync();
        }
        //read by id
        public async Task<Client?> ReadClientById(int id)
        {
            return await _context.Client.FirstOrDefaultAsync(c => c.ClientID == id);
        }
    }
}
