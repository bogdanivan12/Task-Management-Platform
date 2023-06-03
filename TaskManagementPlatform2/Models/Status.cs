using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}
