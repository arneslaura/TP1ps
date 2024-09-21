using Application.Interfaces;
using Application.Request;
using Application.Response;

namespace Application.UseCases
{
    public class TasksService : ITasksService
    {
        private readonly ITasksQuery _query;
        private readonly IProjectQuery _pquery;
        private readonly IUserQuery _uquery;
        private readonly ITaskStatusQuery _tsquery;
        private readonly ITasksCommand _command;
        private readonly ITasksMapper _mapper;

        public TasksService(ITasksQuery query, IProjectQuery pquery, IUserQuery uquery, ITaskStatusQuery tsquery,
            ITasksMapper mapper, ITasksCommand command)
        {
            _query = query;
            _pquery = pquery;
            _uquery = uquery;
            _tsquery = tsquery;
            _mapper = mapper;
            _command = command;
        }

        //create
        public async Task<TasksResponse> CreateTask(Guid projectId, TasksRequest request)
        {
            if (await _pquery.ReadProjectById(projectId) == null)
            {
                throw new NotFoundException($"No project found with ID {projectId}.");
            }
            if (request.Name == "string")
            {
                throw new BadRequestException("The request contains unacceptable default values");
            }
            if (await _uquery.ReadUserById(request.User) == null)
            {
                throw new NotFoundException($"No user found with ID {request.User}.");
            }
            if (await _tsquery.ReadTaskStatusById(request.Status) == null)
            {
                throw new NotFoundException($"No task status found with ID {request.Status}.");
            }
            var task = await _mapper.CreateT(projectId, request);
            var result = await _command.CreateTask(task);
            return await _mapper.GetTaskResponse(result);
        }
        //get all by project id
        public async Task<List<TasksResponse>> GetAllTasksByProjectId(Guid projectId)
        {
            var list = await _query.ReadAllTasksByProjectId(projectId);
            return await _mapper.GetAllTasksResponse(list);
        }
        //update
        public async Task<TasksResponse> UpdateTasks(Guid id, TasksRequest request)
        {
            var task = await _query.ReadTaskById(id);
            if (task == null)
            {
                throw new NotFoundException($"No task found with ID {id}.");
            }
            if (request.Name == "string")
            {
                throw new BadRequestException("The request contains unacceptable default values");
            }
            if (await _uquery.ReadUserById(request.User) == null)
            {
                throw new NotFoundException($"No user found with ID {request.User}.");
            }
            if (await _tsquery.ReadTaskStatusById(request.Status) == null)
            {
                throw new NotFoundException($"No task status found with ID {request.Status}.");
            }
            task.Name = request.Name;
            task.DueDate = request.DueDate;
            task.UpdateDate=DateTime.UtcNow;
            task.AssignedTo = request.User;
            task.Status = request.Status;
            var result = await _command.UpdateTask(task);
            return await _mapper.GetTaskResponse(result);
        }
    }
}
