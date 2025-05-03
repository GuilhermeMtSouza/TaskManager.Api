using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        private readonly IMapper _mapper;
        public ProjectRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
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
            var item = await context.Projects
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public Task<ProjectModel> Update(Guid Id, ProjectModel item)
        {
            var oldProject = context.Projects.AsNoTracking().FirstOrDefault(x => x.Id == Id);
            if (oldProject is null)
            {
                throw new InvalidOperationException("Project not found");
            }

            var UpdatedItem = _mapper.Map(item, oldProject);
            context.Projects.Update(UpdatedItem);
            context.SaveChanges();
            return Task.FromResult(UpdatedItem);
        }
    }
}
