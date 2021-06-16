using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public StoreRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public IQueryable<Product> Products => _storeDbContext.Products;
    }
}
