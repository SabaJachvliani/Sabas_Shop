using Application.Interfaces.Infrastructure;
using Domain.Entities;
using Domain.Entities.RefreshToken;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.SabaShopDbContext
{
    public class SabaShopDb : DbContext, ISabaShopDb
    {
        public SabaShopDb(DbContextOptions<SabaShopDb> options)
            : base(options) { }

        public DbSet<ShopProductPhoto> ProductPhotos => Set<ShopProductPhoto>();
        public DbSet<ShopProductCategory> Categories => Set<ShopProductCategory>();
        public DbSet<ShopProduct> Products => Set<ShopProduct>();
        public DbSet<ShopOrderItem> OrderItems => Set<ShopOrderItem>();
        public DbSet<ShopOrder> Orders => Set<ShopOrder>();
        public DbSet<ShopCostumer> Costumers => Set<ShopCostumer>();
        public DbSet<ShopCastumersInformation> CostumersInformation => Set<ShopCastumersInformation>();
        public DbSet<ShopRefreshToken> RefreshTokens => Set<ShopRefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SabaShopDb).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
