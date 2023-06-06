using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Numele task-ului este obligatoriu")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Deadline { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project? Project { get; set; }

        [Required(ErrorMessage = "Statusul este obligatoriu")]
        public int? StatusId { get; set; }

        public virtual Status? Status { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<TaskMember>? Members { get; set; }
    }
}
