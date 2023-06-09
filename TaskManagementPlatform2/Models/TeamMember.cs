﻿using Microsoft.EntityFrameworkCore;

namespace TaskManagementPlatform2.Models
{
    [PrimaryKey(nameof(UserId), nameof(TeamId))]
    public class TeamMember
    {
        public string? UserId { get; set; }

        public int? TeamId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        public virtual Team? Team { get; set; }
    }
}