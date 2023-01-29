using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.EntityTypeConfigurations
{
    public class FridgeProductConfiguration : IEntityTypeConfiguration<FridgeProduct>
    {
        public void Configure(EntityTypeBuilder<FridgeProduct> builder)
        {
            builder.HasKey(fridgeProduct => fridgeProduct.Id);
            builder.HasKey(fridgeProduct => new object[] { fridgeProduct.FridgeId, fridgeProduct.ProductId });
            builder.HasIndex(fridgeProduct => fridgeProduct.Id).IsUnique();
            builder.HasIndex(fridgeProduct => new object[] { fridgeProduct.FridgeId, fridgeProduct.ProductId }).IsUnique();
        }
    }
}
