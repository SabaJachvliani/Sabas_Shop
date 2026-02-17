using Application.Interfaces.Infrastructure;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.SabaShopDbContext
{
    public class SabaShopDb : DbContext, ISabaShopDb
    {
        public SabaShopDb(DbContextOptions<SabaShopDb> options)
            : base(options)
        {
        }
        
        public DbSet<ShopProductCategory> Categories => Set<ShopProductCategory>();
        public DbSet<ShopProduct> Products => Set<ShopProduct>();
        public DbSet<ShopOrderItem> OrderItems => Set<ShopOrderItem>();
        public DbSet<ShopOrder> Orders => Set<ShopOrder>();
        public DbSet<ShopCostumer> Costumers => Set<ShopCostumer>();
        public DbSet<ShopCastumersInformation> CostumersInformation => Set<ShopCastumersInformation>();

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Loads all IEntityTypeConfiguration<> from Infrastructure assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SabaShopDb).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
