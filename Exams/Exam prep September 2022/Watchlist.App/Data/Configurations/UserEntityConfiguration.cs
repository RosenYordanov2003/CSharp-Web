namespace Watchlist.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Watchlist.Data.Models;
    using static WatchList.Common.EntityValidation.UserEntity;
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(UsernameMaxLength);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(UserEmailMaxLength);
        }
    }
}
