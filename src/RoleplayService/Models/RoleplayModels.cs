using System;
using System.Collections.Generic;

namespace RoleplayService.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;  // e.g., Mafia, Detective, Citizen
        public int Level { get; set; }
        public int Coins { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;   // e.g., Mafia, Doctor
        public string Description { get; set; } = string.Empty;
    }

    public class RoleplayAction
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Ability { get; set; } = string.Empty;   // e.g., "Kill", "Investigate"
        public int? TargetCharacterId { get; set; }           // nullable if action has no target
        public string State { get; set; } = string.Empty;    // Morning, Afternoon, Night, Voting
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class Announcement
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Visibility { get; set; } = "All"; // e.g., "Mafia", "Town", "All"
    }
}
