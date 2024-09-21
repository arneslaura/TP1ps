using Application.Interfaces;
using Application.Response;

namespace Application.Mapper
{
    public class TaskStatusMapper : ITaskStatusMapper
    {
        //mapeo de lista de TaskStatus a lista de GenericResponse
        public Task<List<GenericResponse>> GetAllTaskStatusResponse(List<Domain.Entities.TaskStatus> TaskStatus)
        {
            List<GenericResponse> lista = new List<GenericResponse>();
            foreach (var ts in TaskStatus)
            {
                var response = new GenericResponse
                {
                    Id = ts.Id,
                    Name = ts.Name,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }
        //mapeo de TaskStatus a GenericResponse
        public Task<GenericResponse> GetTaskStatusResponse(Domain.Entities.TaskStatus ts)
        {
            var response = new GenericResponse
            {
                Id = ts.Id,
                Name = ts.Name,
            };
            return Task.FromResult(response);
        }
    }
}
