namespace Contacts.Data.Configurations
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(new Contact()
            {
                Id = 1,
                FirstName = "Bruce",
                LastName = "Wayne",
                PhoneNumber = "+359881223344",
                Address = "Gotham City",
                Email = "imbatman@batman.com",
                Website = "www.batman.com"
            });
        }
    }
}
