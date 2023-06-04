using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberId { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Team>? Teams { get; set; }

        public virtual ICollection<Task>? Tasks { get; set; }
    }
}
