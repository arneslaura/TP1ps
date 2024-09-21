using Application.Interfaces;
using Application.Request;
using Application.Response;

namespace Application.UseCases
{
    public class InteractionsService : IInteractionsService
    {
        private readonly IInteractionsQuery _query;
        private readonly IProjectQuery _pquery;
        private readonly IInteractionTypesQuery _itquery;
        private readonly IInteractionsCommand _command;
        private readonly IInteracionsMapper _mapper;

        public InteractionsService(IInteractionsQuery query, IProjectQuery pquery, IInteractionTypesQuery itquery, 
            IInteractionsCommand command, IInteracionsMapper mapper)
        {
            _query = query;
            _pquery = pquery;
            _itquery = itquery;
            _command = command;
            _mapper = mapper;
        }

        //create
        public async Task<InteractionsResponse> CreateInteraction(Guid projectId, InteractionRequest request)
        {
            if (await _pquery.ReadProjectById(projectId) == null)
            {
                throw new NotFoundException($"No project found with ID {projectId}.");
            }
            if (request.Notes == "string")
            {
                throw new BadRequestException("The request contains unacceptable default values");
            }
            if (await _itquery.ReadInteractionTypesById(request.InteractionType) == null)
            {
                throw new NotFoundException($"No interaction type found with ID {request.InteractionType}.");
            }
            var interaction = await _mapper.CreateI(projectId, request);
            var result = await _command.CreateInteraction(interaction);
            return await _mapper.GetInteractionsResponse(result);
        }
        //get by project id
        public async Task<List<InteractionsResponse>> GetAllInteractionsByProjectId(Guid projectId)
        {
            var list = await _query.ReadAllInteractionsByProjectId(projectId);
            return await _mapper.GetAllInteractionsResponse(list);
        }
    }
}
