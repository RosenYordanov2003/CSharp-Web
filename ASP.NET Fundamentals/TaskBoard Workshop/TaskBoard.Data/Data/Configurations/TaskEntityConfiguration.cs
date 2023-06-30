using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Data.Models;
using Task = TaskBoard.Data.Models.Task;

namespace TaskBoard.Data.Data.Configurations
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(CreateTasks());

        }
        private ICollection<Task> CreateTasks()
        {
            ICollection<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-160),
                     OwnerId = "5f7a965c-65b6-4533-88df-4c9cdcd5d7ff",
                    BoardId = 1
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTfull appi",
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    OwnerId = "5f7a965c-65b6-4533-88df-4c9cdcd5d7ff",
                    BoardId = 2,
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Create Windows Forms desktop client app for the TaskBoard RESTfull appi",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                      OwnerId = "5f7a965c-65b6-4533-88df-4c9cdcd5d7ff",
                    BoardId = 3,
                }
            };
            return tasks;
        }
    }
}
