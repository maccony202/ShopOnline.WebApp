using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
	public class ProductDetailsBase:ComponentBase
	{
		[Parameter]
		public int Id { get; set; }
		[Inject]
		public IProductService ProductService { get; set; }
		public ProductDto Product { get; set; }

		protected override async Task OnInitializedAsync()
		{
			try
			{
				Product = await ProductService.GetProductAsync(Id);
			}
			catch (Exception ex)
			{
				string message = ex.Message;
		
			}
			
		}
	}
}
