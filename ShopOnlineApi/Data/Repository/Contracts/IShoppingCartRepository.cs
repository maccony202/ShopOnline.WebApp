using ShopOnlineApi.Entities;

namespace ShopOnlineApi.Data.Repository.Contracts
{
	public interface IShoppingCartRepository
	{
		Task<CartItem> GetItemsAsync(Cart id);
		Task<CartItem> GetItemAsync(int id);
	}
}

