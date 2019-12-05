using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>(status =>
            {
                status.HasKey(s => s.Name);

                status.Property(s => s.DisplayName)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false);

                status.Property(s => s.Name)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false);

                status.HasData(Status.GetAll());
            });

            modelBuilder.Entity<Task>(task =>
            {
                task.HasKey(t => t.Id);

                task.Property(t => t.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                task.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                task.Property(t => t.Username)
                    .IsRequired(false)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                task.Property(t => t.ProgressPercent)
                    .IsRequired(false);

                task.Property(t => t.StartDate)
                    .IsRequired(false);

                task.Property(t => t.EndDate)
                    .IsRequired(false);

                task.Property(t => t.LastProgressUpdate)
                    .IsRequired(false);

                task.Property(t => t.UserAdId)
                    .IsRequired(false)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                task.Property(t => t.TaskDetails)
                    .IsRequired(false)
                    .IsUnicode(false);

                task.Property(t => t.ProgressDetails)
                    .IsRequired(false)
                    .IsUnicode(false);

                task.HasOne(t => t.Status)
                    .WithMany(s => s.Tasks)
                    .IsRequired();
            });
        }
    }
}
