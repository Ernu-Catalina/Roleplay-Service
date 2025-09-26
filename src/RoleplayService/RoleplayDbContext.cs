using Microsoft.EntityFrameworkCore;
using RoleplayService.Models;

namespace RoleplayService
{
    public class RoleplayDbContext : DbContext
    {
        public RoleplayDbContext(DbContextOptions<RoleplayDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<RoleplayAction> RoleplayActions { get; set; } = null!;
        public DbSet<Announcement> Announcements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("Characters");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<RoleplayAction>().ToTable("Actions");
            modelBuilder.Entity<Announcement>().ToTable("Announcements");
        }
    }
}
