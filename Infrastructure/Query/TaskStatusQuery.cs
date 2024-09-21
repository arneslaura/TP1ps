using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Query
{
    public class TaskStatusQuery : ITaskStatusQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public TaskStatusQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all
        public async Task<List<Domain.Entities.TaskStatus>> ReadAllTaskStatus()
        {
            return await _context.TaskStatus.ToListAsync();
        }
        //read by id
        public Task<Domain.Entities.TaskStatus?> ReadTaskStatusById(int id)
        {
            return _context.TaskStatus.FirstOrDefaultAsync(ts => ts.Id == id);
        }
    }
}
