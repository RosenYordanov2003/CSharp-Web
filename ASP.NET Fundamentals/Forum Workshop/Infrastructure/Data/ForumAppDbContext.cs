namespace Forum_App.Data
{
    using Forum_App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class ForumAppDbContext : DbContext
    {
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPosts();
            modelBuilder.Entity<Post>()
            .HasData(FirstPost, SecondPost, ThirdPost);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedPosts()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "My first Post",
                Content = "I love Man United"
            };
            SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "I hate sharks",
            };
            ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "I don't know what to write"
            };
        }

        public DbSet<Post> Posts { get; init; }
    }
}
