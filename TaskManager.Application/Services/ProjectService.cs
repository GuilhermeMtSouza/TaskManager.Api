using AutoMapper;
using TaskManager.Application.DTOs.Request.Project;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IMapper mapper, IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        public Task<ProjectModel> Add(RequestCreateProjectDto item)
        {
            return _projectRepository.Add(_mapper.Map<ProjectModel>(item));
        }

        public Task<bool> Delete(Guid id)
        {
            return _projectRepository.Delete(id);
        }

        public Task<List<ProjectModel>> GetAllProjectsAsync()
        {
            return _projectRepository.GetAllProjectsAsync();
        }

        public Task<ProjectModel> GetById(Guid id)
        {
            return _projectRepository.GetById(id);
        }

        public Task<ProjectModel> Update(Guid Id, RequestUpdateProjectDto item)
        {
            var Updated = _mapper.Map<ProjectModel>(item);
            Updated.Id = Id;
            return _projectRepository.Update(Id, Updated);
        }
    }
}
