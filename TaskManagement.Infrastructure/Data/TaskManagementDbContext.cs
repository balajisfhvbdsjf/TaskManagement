using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public DbSet<ETask> ETasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Note> Notes { get; set; }

        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Task-User relationship
            modelBuilder.Entity<ETask>()
                .HasOne(t => t.AssignedUser)
                .WithMany(u => u.ETasks)
                .HasForeignKey(t => t.AssignedUserId);

            // User-Team relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Team)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TeamId);

            // Task-Document relationship
            modelBuilder.Entity<Document>()
                .HasOne(d => d.ETask)
                .WithMany(t => t.Documents)
                .HasForeignKey(d => d.TaskId);

            // Task-Note relationship
            modelBuilder.Entity<Note>()
                .HasOne(n => n.ETask)
                .WithMany(t => t.Notes)
                .HasForeignKey(n => n.TaskId);
        }
    }
}
