using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Configurations.ShopEntity
{
    internal class ShopOrderItemConfig : IEntityTypeConfiguration<ShopOrderItem>
    {
        public void Configure(EntityTypeBuilder<ShopOrderItem> builder)
        {
            builder.ToTable("ShopOrderItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.ProductId)
                .IsRequired();
            
            builder.HasIndex(x => new { x.OrderId, x.ProductId })
                .IsUnique();
        }
    }
}
