using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementPlatform2.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string? Description { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Deadline { get; set; }

        public virtual ICollection<Task>? Tasks { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
