using Application.Interfaces;
using Application.Response;

namespace Application.UseCases
{
    public class InteractionTypesServices : IInteractionTypesServices
    {
        private readonly IInteractionTypesQuery _query;
        private readonly IInteractionTypesMapper _mapper;
        public InteractionTypesServices(IInteractionTypesQuery query, IInteractionTypesMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //get all
        public async Task<List<GenericResponse>> GetAllInteractionTypes()
        {
            var list = await _query.ReadAllInteractionTypes();
            return await _mapper.GetAllInteractionTypesResponse(list);
        }
        //get by id
        public async Task<GenericResponse> GetInteractionTypesById(int id)
        {
            var it = await _query.ReadInteractionTypesById(id);
            return await _mapper.GetInteractionTypesResponse(it);
        }
    }
}
