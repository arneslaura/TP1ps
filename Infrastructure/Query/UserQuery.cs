using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class UserQuery : IUserQuery
    {
        //inyeccion de contexto
        private readonly AppDbContext _context;
        public UserQuery(AppDbContext context)
        {
            _context = context;
        }

        //read all
        public async Task<List<User>> ReadAllUsers()
        {
            return await _context.User.ToListAsync();
        }
        //read by id
        public Task<User?> ReadUserById(int id)
        {
            return _context.User.FirstOrDefaultAsync(u => u.UserID == id);
        }
    }
}
