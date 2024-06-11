using ShopOnlineApi.Entities;

namespace ShopOnlineApi.Data.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetItemsCategories();
        Task<Product> GetItem(int id);
		Task<ProductCategory> GetItemCategory(int id);
	}
}
