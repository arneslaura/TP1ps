using Application.Interfaces;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class UserMapper: IUserMapper
    {
        //mapeo de lista de User a lista de UserResponse
        public Task<List<UserResponse>> GetAllUsersResponse(List<User> Users)
        {
            List<UserResponse> lista = new List<UserResponse>();
            foreach (var u in Users)
            {
                var response = new UserResponse
                {
                    Id = u.UserID,
                    Name = u.Name,
                    Email = u.Email,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }
        //mapeo de User a UserResponse
        public Task<UserResponse> GetUserResponse(User u)
        {
            var response = new UserResponse
            {
                Id = u.UserID,
                Name = u.Name,
                Email = u.Email,
            };
            return Task.FromResult(response);
        }
    }
}
