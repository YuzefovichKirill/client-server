using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.EntityTypeConfigurations
{
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasKey(fridgeModel => fridgeModel.Id);
            builder.HasIndex(fridgeModel => fridgeModel.Id).IsUnique();
            builder.Property(fridgeModel => fridgeModel.Name).HasMaxLength(20);
        }
    }
}