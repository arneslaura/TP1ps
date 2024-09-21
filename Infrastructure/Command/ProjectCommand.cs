using Infrastructure.Persistence;
using Domain.Entities;
using Application.Interfaces;

namespace Infrastructure.Command
{
    public class ProjectCommand : IProjectCommand
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public ProjectCommand(AppDbContext context)
        {
            _context = context;
        }

        //create
        public async Task<Project> CreateProject(Project p)
        {
            _context.Project.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }
        //update
        public async System.Threading.Tasks.Task UpdateProject(Project p)
        {
            _context.Project.Update(p);
            await _context.SaveChangesAsync();
        }
    }
}
