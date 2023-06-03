using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime Deadline { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
