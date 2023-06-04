using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementPlatform2.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Numele proiectului este obligatoriu")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Deadline { get; set; }

        public virtual ICollection<Task>? Tasks { get; set; }

        [Required(ErrorMessage = "Este obligatoriu sa selectati o echipa")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
