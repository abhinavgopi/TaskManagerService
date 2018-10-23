using System.Data.Entity;
using TaskManager.Entities;

namespace TaskManager.DataLib
{
    public class TaskManagerContext : DbContext
    {

        public TaskManagerContext() : base("name=TaskManagerContext")
        {
         //   Database.SetInitializer<TaskManagerContext>(new CreateDatabaseIfNotExists<TaskManagerContext>());
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasKey<int>(a => a.TaskId);
            modelBuilder.Entity<Task>().Property(a => a.TaskId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Task>().Property(a => a.TaskName).IsRequired();
            modelBuilder.Entity<Task>().Property(a => a.Priority).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.ParentTaskId).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.StartDate).HasColumnType("Date").IsRequired();
            modelBuilder.Entity<Task>().Property(a => a.EndDate).HasColumnType("Date").IsRequired();
            modelBuilder.Entity<Task>().Property(a => a.IsEnded).IsOptional();

            base.OnModelCreating(modelBuilder);
        }
    }
}
