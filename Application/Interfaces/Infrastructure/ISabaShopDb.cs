using Domain.Entities;
using Domain.Entities.RefreshToken;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Infrastructure
{
    public interface ISabaShopDb
    {
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;

        public DbSet<ShopProductCategory> Categories { get;  }
        public DbSet<ShopProduct> Products {  get;  }
        public DbSet<ShopOrderItem> OrderItems {  get;  }
        public DbSet<ShopCostumer> Costumers {  get;  }
        public DbSet<ShopCastumersInformation> CostumersInformation {  get;  }
        public DbSet<ShopRefreshToken> RefreshTokens {  get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    }
}
