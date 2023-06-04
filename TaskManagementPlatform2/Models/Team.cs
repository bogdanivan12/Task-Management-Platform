using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required(ErrorMessage ="Numele echipei este obligatoriu")]
        public string? Name { get; set; }

        public virtual ICollection<Project>? Projects { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<TeamMember>? Members { get; set; }
    }
}
