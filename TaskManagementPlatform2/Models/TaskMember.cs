using Microsoft.EntityFrameworkCore;

namespace TaskManagementPlatform2.Models
{
    [PrimaryKey(nameof(UserId), nameof(TaskId))]
    public class TaskMember
    {
        public string? UserId { get; set; }

        public int? TaskId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        public virtual Task? Team { get; set; }
    }
}
