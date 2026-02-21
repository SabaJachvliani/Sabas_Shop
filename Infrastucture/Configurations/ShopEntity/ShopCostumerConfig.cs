using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Configurations.ShopEntity
{
    internal class ShopCostumerConfig : IEntityTypeConfiguration<ShopCostumer>
    {
        public void Configure(EntityTypeBuilder<ShopCostumer> builder)
        {
            builder.ToTable("ShopCostumers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);            
                      
            // 1 Customer -> Many Orders
            builder.HasMany(x => x.ShopOrders)
                .WithOne(o => o.ShopCostumers)
                .HasForeignKey(o => o.CostumerId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1 Customer -> Many CustomerInformations
            builder.HasMany(x => x.CastumersInformations)
                .WithOne(i => i.ShopCostumers)
                .HasForeignKey(i => i.CostumerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
