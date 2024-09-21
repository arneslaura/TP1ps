using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;

namespace Infrastructure.Query
{
    public class InteractionTypesQuery : IInteractionTypesQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public InteractionTypesQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all
        public async Task<List<InteractionTypes>> ReadAllInteractionTypes()
        {
            return await _context.InteractionTypes.ToListAsync();
        }
        //read by id
        public Task<InteractionTypes?> ReadInteractionTypesById(int id)
        {
            return _context.InteractionTypes.FirstOrDefaultAsync(it => it.Id == id);
        }
    }
}
