using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.EntityTypeConfigurations
{
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasKey(fridge => fridge.Id);
            builder.HasIndex(fridge => fridge.Id).IsUnique();
            builder.Property(fridge => fridge.OwnerName).HasMaxLength(20);
            builder.Property(fridge => fridge.Name).HasMaxLength(20);
        }
    }
}
