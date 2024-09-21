using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserQuery
    {
        Task<List<User>> ReadAllUsers();
        Task<User?> ReadUserById(int id);
    }
}
