using System.Text;
using TaskManager.Domain.Models;
using Newtonsoft.Json;

namespace TaskManager.Test
{
    public class ProjectControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;

        public ProjectControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetProjects_ReturnsOkResponse()
        {
            var response = await _client.GetAsync("/api/project");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Project", content);
        }

        [Fact]
        public async Task CreateProject_ReturnsCreatedResponse()
        {
            var newProject = new ProjectModel
            {
                Name = "Test Project",
                Description = "Test Project Description"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(newProject),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _client.PostAsync("/api/project", content);

            response.EnsureSuccessStatusCode();

            var createdProject = await response.Content.ReadAsStringAsync();
            Assert.Contains("Test Project", createdProject);
        }
    }

}
