using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class TasksMapper : ITasksMapper
    {
        private readonly ITaskStatusMapper _tSMapper;
        private readonly IUserMapper _uMapper;
        private readonly IUserServices _uservices;
        private readonly ITaskStatusServices _tSService;

        public TasksMapper(ITaskStatusMapper tSMapper, IUserMapper uMapper, IUserServices uservices, ITaskStatusServices tSService)
        {
            _tSMapper = tSMapper;
            _uMapper = uMapper;
            _uservices = uservices;
            _tSService = tSService;
        }

        //mapeo de TaskRequest a Tasks
        public Task<Tasks> CreateT(Guid projectId, TasksRequest request)
        {
            var task = new Tasks
            {
                Name = request.Name,
                DueDate = request.DueDate,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ProjectID = projectId,
                AssignedTo = request.User,
                Status = request.Status,
            };
            return Task.FromResult(task);
        }
        //mapeo de lista de Tasks a lista de TasksResponse
        public async Task<List<TasksResponse>> GetAllTasksResponse(List<Tasks> Tasks)
        {
            List<TasksResponse> lista = new List<TasksResponse>();
            foreach (var t in Tasks)
            {
                var response = new TasksResponse
                {
                    Id = t.TaskID,
                    Name = t.Name,
                    DueDate = t.DueDate,
                    ProjectId = t.ProjectID,
                    Status = await _tSMapper.GetTaskStatusResponse(t.TaskStatus),
                    UserAssigned = await _uMapper.GetUserResponse(t.User),
                };
                lista.Add(response);
            }
            return lista;
        }
        //mapeo de Tasks a TasksResponse
        public async Task<TasksResponse> GetTaskResponse(Tasks t)
        {
            var response = new TasksResponse
            {
                Id = t.TaskID,
                Name = t.Name,
                DueDate = t.DueDate,
                ProjectId = t.ProjectID,
                Status = await _tSService.GetTaskStatusById(t.Status),
                UserAssigned = await _uservices.GetUserById(t.AssignedTo)
            };
            return response;
        }
    }
}
