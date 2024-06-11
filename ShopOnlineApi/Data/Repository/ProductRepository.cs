using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data.Repository.Contracts;
using ShopOnlineApi.Entities;

namespace ShopOnlineApi.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDBContext _shopOnlineDb;
        public ProductRepository(ShopOnlineDBContext shopOnlineDBContext) {
            _shopOnlineDb = shopOnlineDBContext;
        }

		public async Task<Product> GetItem(int id)
		{
            return await _shopOnlineDb.Products.FindAsync(id);
		}


		public async Task<ProductCategory> GetItemCategory(int id)
		{
			return await _shopOnlineDb.ProductCategories.SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Product>> GetItems()
            {
            return await _shopOnlineDb.Products.ToListAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetItemsCategories()
        {
            return await _shopOnlineDb.ProductCategories.ToListAsync();
        }
    }
}
