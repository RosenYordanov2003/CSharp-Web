using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Data.Models;
using Task = TaskBoard.Data.Models.Task;

namespace TaskBoard.Data
{
    public class TaskBoardDbContext : IdentityDbContext
    {
        private IdentityUser testUser;
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);
            SeedUsers();
            builder.Entity<IdentityUser>().HasData(this.testUser);
            builder.Entity<Board>().HasData(SeedBoards());
            builder.Entity<Task>().HasData(SeedTasks());

            base.OnModelCreating(builder);
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }

        private Board[] SeedBoards()
        {
            List<Board> boards = new List<Board>();
            Board openBoard = new Board()
            {
                Id = 1,
                Name = "Open",
            };

            Board InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            Board doneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            boards.Add(openBoard);
            boards.Add(InProgressBoard);
            boards.Add(doneBoard);
            return boards.ToArray();
        }
        private void SeedUsers()
        {
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            this.testUser = new IdentityUser()
            {
                UserName = "test@gmail.com",
                NormalizedUserName = "TEST@GMAIL.COM"
            };
            this.testUser.PasswordHash = passwordHasher.HashPassword(this.testUser, "mypass1234");
        }
        private Task[] SeedTasks()
        {
            List<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-160),
                    OwnerId = this.testUser.Id,
                    BoardId = 1
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTfull appi",
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    OwnerId = this.testUser.Id,
                    BoardId = 2,
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Create Windows Forms desktop client app for the TaskBoard RESTfull appi",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = this.testUser.Id,
                    BoardId = 3,
                }
            };
            return tasks.ToArray();
        }
    }
}