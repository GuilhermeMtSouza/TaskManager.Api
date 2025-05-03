using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using TaskManager.Domain.Models;
using Newtonsoft.Json;

namespace TaskManager.Test
{
    public class TaskControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;

        public TaskControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetTasks_ReturnsOkResponse()
        {
            var response = await _client.GetAsync("/api/task");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Task", content);
        }

        [Fact]
        public async Task CreateTask_ReturnsCreatedResponse()
        {
            var newProject = new ProjectModel
            {
                Name = "Test Project",
                Description = "Project for Task Testing",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(10)
            };

            var projectContent = new StringContent(
                JsonConvert.SerializeObject(newProject),
                Encoding.UTF8,
                "application/json"
            );

            var projectResponse = await _client.PostAsync("/api/project", projectContent);
            projectResponse.EnsureSuccessStatusCode();

            var projectJson = await projectResponse.Content.ReadAsStringAsync();
            var createdProject = JsonConvert.DeserializeObject<ProjectModel>(projectJson);

            // 2. Criar a task vinculada ao projeto
            var newTask = new TaskModel
            {
                Name = "Test Task",
                Description = "Test Task Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                ProjectId = createdProject.Id
            };

            var taskContent = new StringContent(
                JsonConvert.SerializeObject(newTask),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _client.PostAsync("/api/task", taskContent);
            response.EnsureSuccessStatusCode();

            var createdTask = await response.Content.ReadAsStringAsync();
            Assert.Contains("Test Task", createdTask);
        }
    }

}
