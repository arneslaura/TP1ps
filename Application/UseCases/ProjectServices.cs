using Application.Interfaces;
using Application.Request;
using Application.Response;

namespace Application.UseCases
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectQuery _query;
        private readonly IClientQuery _cQuery;
        private readonly ICampaignTypeQuery _cTQuery;
        private readonly IProjectCommand _command;
        private readonly IProjectMapper _mapper;
        private readonly IProjectDataMapper _pdmapper;
        private readonly IInteractionsService _iService;
        private readonly ITasksService _tService;
        public ProjectServices(IProjectQuery query, IClientQuery cQuery, ICampaignTypeQuery cTQuery, IProjectCommand command, IProjectMapper mapper, 
            IProjectDataMapper pdmapper, IInteractionsService iService, ITasksService tService)
        {
            _query = query;
            _cQuery = cQuery;
            _cTQuery = cTQuery;
            _command = command;
            _mapper = mapper;
            _pdmapper = pdmapper;
            _iService = iService;
            _tService = tService;
        }

        //create
        public async Task<ProjectResponse> CreateProject(ProjectRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new BadRequestException("Project name cannot be empty.");
            }
            if (request.Name == "string")
            {
                throw new BadRequestException("The request contains unacceptable default values");
            }
            if (await _query.ReadProjectByName(request.Name) != null)
            {
                throw new AlredyExistException($"A project with the name '{request.Name}' already exists.");
            }
            if (await _cQuery.ReadClientById(request.Client) == null)
            {
                throw new NotFoundException($"No client found with ID {request.Client}.");
            }
            if (await _cTQuery.ReadCampaignTypeById(request.CampaignType) == null)
            {
                throw new NotFoundException($"No campaign type found with ID {request.CampaignType}.");
            }
            var project = await _mapper.CreateP(request);
            var result = await _command.CreateProject(project);
            return await _mapper.GetProjectResponse(result);
        }
        //get all (optional filters)
        public async Task<List<ProjectDataResponse>> GetProjectsData(string? name, int? ctId, int? cId, int? offset, int? size)
        {
            if (offset.HasValue && offset < 0)
            {
                throw new BadRequestException("Offset must be greater than or equal to 0.");
            }

            if (size.HasValue && size < 0)
            {
                throw new BadRequestException("Size must be greater than or equal to 0.");
            }
            var list = await _query.ReadAllProjectsData(name, ctId, cId, offset, size);
            return await _pdmapper.GetProjectDataResponse(list);
        }
        //get by id
        public async Task<ProjectResponse> GetProjectById(Guid id)
        {
            var p = await _query.ReadProjectById(id);
            if (p == null)
            {
                throw new NotFoundException($"No project found with ID {id}.");
            }
            return await _mapper.GetProjectResponse(p);
        }
        //add interaction
        public async Task<InteractionsResponse> AddInteractionToTheProject(Guid projectId, InteractionRequest request)
        {
            var interacction = await _iService.CreateInteraction(projectId, request);
            var project = await _query.ReadProjectById(projectId);
            project.UpdateDate = DateTime.UtcNow;
            await _command.UpdateProject(project);
            return interacction;
        }
        //add task
        public async Task<TasksResponse> AddTaskToTheProject(Guid projectId, TasksRequest request)
        {
            var interacction = await _tService.CreateTask(projectId, request);
            var project = await _query.ReadProjectById(projectId);
            project.UpdateDate = DateTime.UtcNow;
            await _command.UpdateProject(project);
            return interacction;
        }
        //update task
        public async Task<TasksResponse> UpdateTaskToTheProject(Guid TaskId, TasksRequest request)
        {
            var task = await _tService.UpdateTasks(TaskId, request);
            var project = await _query.ReadProjectById(task.ProjectId);
            project.UpdateDate = DateTime.UtcNow;
            await _command.UpdateProject(project);
            return task;
        }
    }
}
