using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Mapper
{
    public class ProjectMapper : IProjectMapper
    {
        private readonly IProjectDataMapper _pDMapper;
        private readonly IInteractionsService _iService;
        private readonly ITasksService _tService;


        public ProjectMapper(IProjectDataMapper pDMapper, IInteractionsService iService, ITasksService tService)
        {
            _pDMapper = pDMapper;
            _iService = iService;
            _tService = tService;
        }

        //mapeo de ProjectRequest a Project
        public Task<Project> CreateP(ProjectRequest request)
        {
            var project = new Project
            {
                ProjectName = request.Name,
                StartDate = request.Start,
                EndDate = request.End,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ClientID = request.Client,
                CampaignType = request.CampaignType,
            };
            return Task.FromResult(project);
        }
        //mapeo de Project a ProjectResponse
        public async Task<ProjectResponse> GetProjectResponse(Project p)
        {
            var response = new ProjectResponse
            {
                Data = await _pDMapper.GetProjectDataResponse(p),
                Interactions= await _iService.GetAllInteractionsByProjectId(p.ProjectID),
                Tasks= await _tService.GetAllTasksByProjectId(p.ProjectID),
            };
            return response;
        }
    }
}
