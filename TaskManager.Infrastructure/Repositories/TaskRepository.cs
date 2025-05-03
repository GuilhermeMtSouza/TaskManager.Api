using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        private readonly IMapper _mapper;
        public TaskRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> Add(TaskModel item)
        {
            var parent = context.Projects.FirstOrDefault(x => x.Id == item.ProjectId);
            if (parent is null)
            {
                throw new InvalidOperationException("Project not found");
            }

            await context.Tasks.AddAsync(item);
            context.SaveChanges();
            return item;
        }

        public async Task<bool> Delete(Guid id)
        {
            var item = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if(item is null)
            {
                throw new InvalidOperationException("Task not found");
            }

            context.Tasks.Remove(item);
            context.SaveChanges();
            
            return true;
        }

        public Task<TaskModel> Update(Guid id, TaskModel item)
        {
            var task = context.Tasks.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (task is null)
            {
                throw new InvalidOperationException("Task not found");
            }

            var parent = context.Projects.FirstOrDefault(x => x.Id == item.ProjectId);
            if (parent is null)
            {
                throw new InvalidOperationException("Project not found");
            }

            var updatedItem = _mapper.Map(item, task);

            context.Tasks.Update(updatedItem);
            context.SaveChanges();

            return Task.FromResult(updatedItem);
        }

        public async Task<TaskModel> GetById(Guid id)
        {
            var item = await context.Tasks
                .Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }
    }
}
