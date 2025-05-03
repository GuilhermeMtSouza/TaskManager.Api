using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Request.Task;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasksAsync();
        Task<TaskModel> Add(RequestCreateTaskDto item);
        Task<bool> Delete(Guid id);
        Task<TaskModel> Update(TaskModel item);
        Task<TaskModel> GetById(Guid id);
    }
}
