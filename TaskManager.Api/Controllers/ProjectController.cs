using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Request.Project;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Models;

namespace TaskManager.Api.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _projectService.GetAllProjectsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RequestCreateProjectDto projectModel)
        {
            return Ok(await _projectService.Add(projectModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] RequestCreateProjectDto projectModel)
        {
            return Ok(await _projectService.Update(Id, projectModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _projectService.Delete(id));
        }
    }
}
