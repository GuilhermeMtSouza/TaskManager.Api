using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public TaskPriority Priority { get; set; }
        public Guid ProjectId { get; set; }

        [JsonIgnore]
        public virtual ProjectModel Project { get; set; }
    }
}
