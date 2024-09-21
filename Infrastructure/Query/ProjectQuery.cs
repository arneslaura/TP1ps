using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;

namespace Infrastructure.Query
{
    public class ProjectQuery : IProjectQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public ProjectQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all
        public async Task<List<Project>> ReadAllProjectsData(string? name, int? ctId, int? cId, int? offset = 0, int? size = 10)
        {
            var projects = _context.Project
                .Include(p => p.Campaigntype)
                .Include(p => p.Client)
                .Where(p => (p.ProjectName == name || string.IsNullOrEmpty(name)) && (p.CampaignType == ctId ||
                    !ctId.HasValue) && (p.ClientID == cId || !cId.HasValue));
            if (offset.HasValue)
            {
                projects = projects.Skip(offset.Value); 
            }
            if (size.HasValue)
            {
                projects = projects.Take(size.Value); 
            }
            return await projects.ToListAsync();
        }
        //read by id
        public async Task<Project?> ReadProjectById(Guid projectId)
        {
            return await _context.Project
                .Include(p => p.Campaigntype)
                .Include(p => p.Client)
                .FirstOrDefaultAsync(p => p.ProjectID == projectId);
        }
        //read by name
        public async Task<Project?> ReadProjectByName(string name)
        {
            return await _context.Project
                .Include(p => p.Campaigntype)
                .Include(p => p.Client)
                .FirstOrDefaultAsync(p => p.ProjectName == name);
        }
    }
}
