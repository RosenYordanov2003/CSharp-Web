namespace Contacts.Data.Configurations
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Common.EntityValidation.ApplicationUserEntity;
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.UserName).HasMaxLength(UserNameMaxLength);
            builder.Property(p => p.Email).HasMaxLength(EmailMaxLength);
        }
    }
}
