using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class InteracionsMapper : IInteracionsMapper
    {
        private readonly IInteractionTypesMapper _itMapper;
        private readonly IInteractionTypesServices _itServices;

        public InteracionsMapper(IInteractionTypesMapper itMapper, IInteractionTypesServices itServices)
        {
            _itMapper = itMapper;
            _itServices = itServices;
        }

        //mapeo de InteractionsRequest a Interactions
        public Task<Interactions> CreateI(Guid projectId, InteractionRequest request)
        {
            var interactions = new Interactions
            {
                Date = request.Date,
                Notes = request.Notes,
                ProjectID = projectId,
                InteractionType = request.InteractionType,
            };
            return Task.FromResult(interactions);
        }
        //mapeo de lista de Interactions a lista de InteractionsResponse
        public async Task<List<InteractionsResponse>> GetAllInteractionsResponse(List<Interactions> Interactions)
        {
            List<InteractionsResponse> lista = new List<InteractionsResponse>();
            foreach (var i in Interactions)
            {
                var response = new InteractionsResponse
                {
                    Id = i.InteractionID,
                    Notes = i.Notes,
                    Date = i.Date,
                    ProjectId = i.ProjectID,
                    InteractionType = await _itMapper.GetInteractionTypesResponse(i.Interactiontype),
                };
                lista.Add(response);
            }
            return lista;
        }
        //mapeo de Interactions a InteractionsResponse
        public async Task<InteractionsResponse> GetInteractionsResponse(Interactions i)
        {
            var response = new InteractionsResponse
            {
                Id = i.InteractionID,
                Notes = i.Notes,
                Date = i.Date,
                ProjectId = i.ProjectID,
                InteractionType = await _itServices.GetInteractionTypesById(i.InteractionType),
            };
            return response;
        }
    }
}
