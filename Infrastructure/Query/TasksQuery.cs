using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TasksQuery : ITasksQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public TasksQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all by project id
        public async Task<List<Tasks>> ReadAllTasksByProjectId(Guid projectId)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .Include(t => t.TaskStatus)
                .Where(t => t.ProjectID == projectId)
                .ToListAsync();
        }
        //read by id
        public async Task<Tasks?> ReadTaskById(Guid Id)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .Include(t => t.TaskStatus)
                .FirstOrDefaultAsync(t => t.TaskID == Id);
        }
    }
}
