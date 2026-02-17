using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.Configurations.ShopEntity
{
    internal class ShopCastumersInformationConfig : IEntityTypeConfiguration<ShopCastumersInformation>
    {
        public void Configure(EntityTypeBuilder<ShopCastumersInformation> builder)
        {
            builder.ToTable("ShopCastumersInformations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Mail)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Addres)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.CostumerId)
                .IsRequired();
            
        }
    }
}
