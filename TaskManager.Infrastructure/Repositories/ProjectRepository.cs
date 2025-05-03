using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<ProjectModel> Add(ProjectModel item)
        {
            var added = await context.Projects.AddAsync(item);
            context.SaveChanges();

            return item;
        }

        public async Task<bool> Delete(Guid id)
        {
            var item = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (item is null)
            {
                throw new InvalidOperationException("Project not found");
            }
            context.Projects.Remove(item);
            context.SaveChanges();
            return true;
        }

        public async Task<List<ProjectModel>> GetAllProjectsAsync()
        {
            return await context.Projects.ToListAsync();
        }

        public async Task<ProjectModel> GetById(Guid id)
        {
            var item = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public Task<ProjectModel> Update(Guid Id, ProjectModel item)
        {
            var project = context.Projects.FirstOrDefault(x => x.Id == Id);
            if (project is null)
            {
                throw new InvalidOperationException("Project not found");
            }
            context.Projects.Update(item);
            context.SaveChanges();
            return Task.FromResult(item);
        }
    }
}
