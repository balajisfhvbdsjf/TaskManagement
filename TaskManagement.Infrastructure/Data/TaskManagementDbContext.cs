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
        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    // Seed Users
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", TeamId = 1 },
        //        new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", TeamId = 1 },
        //        new User { Id = 3, Name = "Michael Johnson", Email = "michael.johnson@example.com", TeamId = 2 },
        //        new User { Id = 4, Name = "Emily Brown", Email = "emily.brown@example.com", TeamId = 2 },
        //        new User { Id = 5, Name = "David Lee", Email = "david.lee@example.com", TeamId = 1 },
        //        new User { Id = 6, Name = "Emma White", Email = "emma.white@example.com", TeamId = 2 },
        //        new User { Id = 7, Name = "Sarah Green", Email = "sarah.green@example.com", TeamId = 3 },
        //        new User { Id = 8, Name = "Kevin Clark", Email = "kevin.clark@example.com", TeamId = 3 }
        //    // Add more users as needed
        //    );

        //    // Seed Teams
        //    modelBuilder.Entity<Team>().HasData(
        //        new Team { Id = 1, Name = "Development Team" },
        //        new Team { Id = 2, Name = "Marketing Team" },
        //        new Team { Id = 3, Name = "Sales Team" },
        //        new Team { Id = 4, Name = "Support Team" }
        //    // Add more teams as needed
        //    );

        //    // Seed Tasks
        //    modelBuilder.Entity<ETask>().HasData(
        //        new ETask
        //        {
        //            Id = 1,
        //            Title = "Implement Authentication",
        //            Description = "Implement JWT authentication in ASP.NET Core API",
        //            Status = TaskStatus.Pending,
        //            DueDate = DateTime.UtcNow.AddDays(7),
        //            AssignedUserId = 1
        //        },
        //        new ETask
        //        {
        //            Id = 2,
        //            Title = "Design Landing Page",
        //            Description = "Create wireframes and design concepts for the new landing page",
        //            Status = TaskStatus.Pending,
        //            DueDate = DateTime.UtcNow.AddDays(14),
        //            AssignedUserId = 2
        //        },
        //        new ETask
        //        {
        //            Id = 3,
        //            Title = "Update Marketing Strategy",
        //            Description = "Revise the current marketing strategy based on latest trends",
        //            Status = TaskStatus.InProgress,
        //            DueDate = DateTime.UtcNow.AddDays(10),
        //            AssignedUserId = 3
        //        },
        //        new ETask
        //        {
        //            Id = 4,
        //            Title = "Deploy New Feature Set",
        //            Description = "Deploy new features developed in sprint 2",
        //            Status = TaskStatus.Pending,
        //            DueDate = DateTime.UtcNow.AddDays(5),
        //            AssignedUserId = 4
        //        },
        //        new ETask
        //        {
        //            Id = 5,
        //            Title = "Write User Guide",
        //            Description = "Create documentation for end users explaining new features",
        //            Status = TaskStatus.Pending,
        //            DueDate = DateTime.UtcNow.AddDays(3),
        //            AssignedUserId = 5
        //        }
        //    );

        //    // Seed Documents
        //    modelBuilder.Entity<Document>().HasData(
        //        new Document { Id = 1, FileName = "Design Specs", FilePath = "/documents/design_specs.pdf", TaskId = 2 },
        //        new Document { Id = 2, FileName = "Project Proposal", FilePath = "/documents/project_proposal.docx", TaskId = 1 },
        //        new Document { Id = 3, FileName = "User Guide Draft", FilePath = "/documents/user_guide_draft.pdf", TaskId = 5 },
        //        new Document { Id = 4, FileName = "Marketing Campaign Plan", FilePath = "/documents/marketing_campaign_plan.docx", TaskId = 3 }
        //    // Add more documents as needed
        //    );

        //    // Seed Notes
        //    modelBuilder.Entity<Note>().HasData(
        //        new Note { Id = 1, Content = "Meeting scheduled with stakeholders", TaskId = 1 },
        //        new Note { Id = 2, Content = "Updated API documentation", TaskId = 2 },
        //        new Note { Id = 3, Content = "Discuss budget allocation with finance team", TaskId = 3 },
        //        new Note { Id = 4, Content = "Draft email for marketing campaign launch", TaskId = 3 },
        //        new Note { Id = 5, Content = "Review user feedback for recent feature release", TaskId = 4 }
        //    // Add more notes as needed
        //    );
        //}

    }
}
