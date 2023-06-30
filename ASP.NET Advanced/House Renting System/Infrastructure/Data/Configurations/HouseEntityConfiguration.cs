namespace Infrastructure.Data.Configurations
{
    using Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HouseEntityConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasOne(h => h.Agent)
                .WithMany(a => a.OwnedHouses)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(h => h.Renter)
                .WithMany(r => r.RentedHouses)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(h => h.Category)
                .WithMany(c => c.Houses)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
