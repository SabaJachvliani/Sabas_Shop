using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Configurations.ShopEntity
{
    internal class ShopProductPhotoConfig : IEntityTypeConfiguration<ShopProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ShopProductPhoto> builder)
        {
            builder.ToTable("ShopProductPhotos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.ProductId, x.Order }).IsUnique();
        }
    }
}
