using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementPlatform2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Team>? Teams { get; set; }

        public virtual ICollection<Project>? Projects { get; set; }
        
        public virtual ICollection<Task>? Tasks { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual ICollection<Status>? Statuses { get; set; }

    }
}
