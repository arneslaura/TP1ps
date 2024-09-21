using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Query
{
    public class CampaignTypeQuery : ICampaignTypeQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public CampaignTypeQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all
        public async Task<List<CampaignType>> ReadAllCampaignTypes()
        {
            return await _context.CampaignType.ToListAsync();
        }
        //read by id
        public async Task<CampaignType?> ReadCampaignTypeById(int id)
        {
            return await _context.CampaignType.FirstOrDefaultAsync(ct => ct.Id == id);
        }
    }
}
