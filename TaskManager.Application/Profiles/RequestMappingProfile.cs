using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Request.Project;
using TaskManager.Application.DTOs.Request.Task;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Profiles
{
    public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {
            #region Project
            CreateMap<RequestCreateProjectDto, ProjectModel>();
            #endregion

            #region Task
            CreateMap<RequestCreateTaskDto, TaskModel>();
            #endregion
        }
    }
}
