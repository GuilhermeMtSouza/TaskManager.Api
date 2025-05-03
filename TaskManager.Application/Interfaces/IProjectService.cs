using TaskManager.Application.DTOs.Request.Project;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectModel>> GetAllProjectsAsync();
        Task<ProjectModel> Add(RequestCreateProjectDto item);
        Task<ProjectModel> Update(Guid Id, RequestCreateProjectDto item);
        Task<bool> Delete(Guid id);
        Task<ProjectModel> GetById(Guid id);
    }
}
