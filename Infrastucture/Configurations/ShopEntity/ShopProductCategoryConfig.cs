using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.Configurations.ShopEntity
{
    internal class ShopProductCategoryConfig : IEntityTypeConfiguration<ShopProductCategory>
    {
        public void Configure(EntityTypeBuilder<ShopProductCategory> builder)
        {
            builder.ToTable("ShopProductCategories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(120);
            
            builder.HasMany(x => x.ShopProducts)
                .WithOne(p => p.ShopProductCategorys)   
                .HasForeignKey(p => p.Product_CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
