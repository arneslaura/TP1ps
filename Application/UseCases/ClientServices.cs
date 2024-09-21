using Application.Interfaces;
using Application.Request;
using Application.Response;

namespace Application.UseCases
{
    public class ClientServices : IClientServices
    {
        private readonly IClientQuery _query;
        private readonly IClientCommand _command;
        private readonly IClientMapper _mapper;
        public ClientServices(IClientQuery query, IClientCommand command, IClientMapper mapper)
        {
            _query = query;
            _command = command;
            _mapper = mapper;
        }

        //create
        public async Task<ClientResponse> CreateClient(ClientRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Phone) || string.IsNullOrWhiteSpace(request.Company) ||
                string.IsNullOrWhiteSpace(request.Address))
            {
                throw new BadRequestException("The request contains null or empty values.");
            }
            if (request.Name == "string" || request.Email == "string" || request.Phone == "string" || request.Company == "string" || request.Address == "string")
            {
                throw new BadRequestException("The request contains unacceptable default values");
            }
            var client = await _mapper.CreateC(request);
            var result = await _command.CreateClient(client);
            return await _mapper.GetClientResponse(result);
        }
        //get all
        public async Task<List<ClientResponse>> GetAllClients()
        {
            var list = await _query.ReadAllClients();
            return await _mapper.GetAllClientsResponse(list);
        }
        //get by id
        public async Task<ClientResponse> GetClientById(int id)
        {
            var c = await _query.ReadClientById(id);
            return await _mapper.GetClientResponse(c);
        }
    }
}
