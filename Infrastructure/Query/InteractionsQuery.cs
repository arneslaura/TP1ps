using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class InteractionsQuery : IInteractionsQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public InteractionsQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all by project id
        public async Task<List<Interactions>> ReadAllInteractionsByProjectId(Guid projectId)
        {
            return await _context.Interactions
                .Include(i => i.Interactiontype)
                .Where(i => i.ProjectID == projectId)
                .ToListAsync();
        }
    }
}
