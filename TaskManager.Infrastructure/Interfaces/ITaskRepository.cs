using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Models;

namespace TaskManager.Infrastructure.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasksAsync();
        Task<TaskModel> Add(TaskModel item);
        Task<bool> Delete(Guid id);
        Task<TaskModel> Update(Guid id, TaskModel item);
        Task<TaskModel> GetById(Guid id);
    }
}
