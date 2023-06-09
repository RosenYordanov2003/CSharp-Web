using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchlist.Data.Models;

namespace Watchlist.Data.Configurations
{
    public class UserMovieEntityConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> builder)
        {
            builder.HasKey(ck => new { ck.UserId, ck.MovieId });
        }
    }
}
