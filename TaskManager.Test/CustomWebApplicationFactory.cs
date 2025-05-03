using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure;

namespace TaskManager.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");

            builder.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                db.Database.EnsureCreated();

                var project = new ProjectModel { Id = Guid.NewGuid(), Name = "Seed Project", Description = "Seed Project Description", status = Domain.Enums.ProjectStatus.NotStarted };
                db.Projects.Add(project);

                db.Tasks.Add(new TaskModel { Id = Guid.NewGuid(), Name = "Seed Task", ProjectId = project.Id, Description = "Seed Task Description", Priority = Domain.Enums.TaskPriority.Medium});

                db.SaveChanges();
            });
        }
    }
}
