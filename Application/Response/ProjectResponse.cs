using System;

namespace Application.Response
{
    public class ProjectResponse
    {
        public ProjectDataResponse Data { get; set; }
        public List<InteractionsResponse> Interactions { get; set; }
        public List<TasksResponse> Tasks { get; set; }
    }
}
