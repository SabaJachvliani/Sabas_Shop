using Domain.Entities.RefreshToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Configurations.RefreshToken
{
    public class ShopRefreshTokenConfig : IEntityTypeConfiguration<ShopRefreshToken>
    {
        public void Configure(EntityTypeBuilder<ShopRefreshToken> b)
        {
            b.HasKey(x => x.Id);

            b.Property(x => x.TokenHash).IsRequired().HasMaxLength(200);
            b.HasIndex(x => x.TokenHash).IsUnique();

            b.HasOne(x => x.User)
                .WithMany() 
                .HasForeignKey(x => x.UserId);
        }
    }
}
