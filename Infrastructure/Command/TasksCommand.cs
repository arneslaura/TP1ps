using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class TasksCommand : ITasksCommand
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public TasksCommand(AppDbContext context)
        {
            _context = context;
        }

        //create
        public async Task<Tasks> CreateTask(Tasks t)
        {
            _context.Tasks.Add(t);
            await _context.SaveChangesAsync();
            return t;
        }
        //update
        public async Task<Tasks> UpdateTask(Tasks t)
        {
            _context.Tasks.Update(t);
            await _context.SaveChangesAsync();
            return t;
        }
    }
}
