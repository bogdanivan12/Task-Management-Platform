﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform2.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Project>? Projects { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ApplicationUser>? Members { get; set; }
    }
}
