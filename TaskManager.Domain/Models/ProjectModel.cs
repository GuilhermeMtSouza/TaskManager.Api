using System.Text.Json.Serialization;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectStatus status { get; set; }

        [JsonIgnore]
        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
