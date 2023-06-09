namespace Watchlist.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Watchlist.Data.Configurations;
    using Watchlist.Data.Models;

    public class WatchlistDbContext : IdentityDbContext<User>
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<UserMovie> UsersMovies { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GenreEntityConfiguration());
            builder.ApplyConfiguration(new UserMovieEntityConfiguration());
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}