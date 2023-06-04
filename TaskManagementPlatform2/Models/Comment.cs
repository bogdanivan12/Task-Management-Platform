using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int TaskId { get; set; }

        public virtual Task Task { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
