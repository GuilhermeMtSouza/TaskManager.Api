using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Models;

namespace TaskManager.Infrastructure.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<ProjectModel>> GetAllProjectsAsync();
        Task<ProjectModel> Add(ProjectModel item);
        Task<ProjectModel> Update(Guid Id, ProjectModel item);
        Task<bool> Delete(Guid id);
        Task<ProjectModel> GetById(Guid id);
    }
}
