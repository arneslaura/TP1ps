using Application.Interfaces;
using Application.Response;

namespace Application.UseCases
{
    public class TaskStatusServices: ITaskStatusServices
    {
        private readonly ITaskStatusQuery _query;
        private readonly ITaskStatusMapper _mapper;
        public TaskStatusServices(ITaskStatusQuery query, ITaskStatusMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //get all
        public async Task<List<GenericResponse>> GetAllTaskStatus()
        {
            var list = await _query.ReadAllTaskStatus();
            return await _mapper.GetAllTaskStatusResponse(list);
        }
        //get by id
        public async Task<GenericResponse> GetTaskStatusById(int id)
        {
            var ts = await _query.ReadTaskStatusById(id);
            return await _mapper.GetTaskStatusResponse(ts);
        }
    }
}

