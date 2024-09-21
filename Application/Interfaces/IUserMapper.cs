using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserMapper
    {
        Task<List<UserResponse>> GetAllUsersResponse(List<User> Users);
        Task<UserResponse> GetUserResponse(User u);
    }
}
