using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {

        public TaskRepository(AppDbContext context) : base(context)
        {
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

        public Task<TaskModel> Update(TaskModel item)
        {
            var task = context.Tasks.FirstOrDefault(x => x.Id == item.Id);
            if (task is null)
            {
                throw new InvalidOperationException("Task not found");
            }
            var parent = context.Projects.FirstOrDefault(x => x.Id == item.ProjectId);
            if (parent is null)
            {
                throw new InvalidOperationException("Project not found");
            }
            context.Tasks.Update(item);
            context.SaveChanges();
            return Task.FromResult(item);
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
