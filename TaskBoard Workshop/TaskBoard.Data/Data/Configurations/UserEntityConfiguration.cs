using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskBoard.Data.Data.Configurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            IdentityUser testUser = CreateUser();
            builder.HasData(testUser);
        }

        private IdentityUser CreateUser()
        {

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            IdentityUser testUser = new IdentityUser()
            {
                UserName = "test@gmail.com",
                NormalizedUserName = "TEST@GMAIL.COM"
            };
            testUser.PasswordHash = passwordHasher.HashPassword(testUser, "mypass1234");

            return testUser;
        }
    }
}
