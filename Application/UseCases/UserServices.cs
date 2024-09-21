using Application.Interfaces;
using Application.Response;

namespace Application.UseCases
{
    public class UserServices : IUserServices
    {
        private readonly IUserQuery _query;
        private readonly IUserMapper _mapper;
        public UserServices(IUserQuery query, IUserMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //get all
        public async Task<List<UserResponse>> GetAllUsers()
        {
            var list = await _query.ReadAllUsers();
            return await _mapper.GetAllUsersResponse(list);
        }
        //get by id
        public async Task<UserResponse> GetUserById(int id)
        {
            var u = await _query.ReadUserById(id);
            return await _mapper.GetUserResponse(u);
        }
    }
}
