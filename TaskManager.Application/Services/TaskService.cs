using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Request.Task;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskModel> Add(RequestCreateTaskDto item)
        {
            var model = _mapper.Map<TaskModel>(item);
            return await _taskRepository.Add(model);
        }

        public Task<bool> Delete(Guid id)
        {
            return _taskRepository.Delete(id);
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public Task<TaskModel> GetById(Guid id)
        {
            return _taskRepository.GetById(id);
        }

        public Task<TaskModel> Update(TaskModel item)
        {
            return _taskRepository.Update(item);
        }
    }
}
