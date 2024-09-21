using Application.Response;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserResponse>> GetAllUsers();
        Task<UserResponse> GetUserById(int id);
    }
}
