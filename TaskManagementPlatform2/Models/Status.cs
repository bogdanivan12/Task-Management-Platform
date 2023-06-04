using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Numele statusului este obligatoriu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Culoarea este obligatorie")]
        public string Color { get; set; }

        public string? UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
