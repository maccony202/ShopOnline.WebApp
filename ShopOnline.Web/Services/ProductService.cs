using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Net;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

		public async Task<ProductDto> GetProductAsync(int id)
		{
            try
            {
                var response = await _httpClient.GetAsync($"api/Product/getitem/{id}");
                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductDto);
                    }
					return await response.Content.ReadFromJsonAsync<ProductDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                
			}
            catch(Exception)
            {
                throw; 
            }
            
		}

		public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Product/getitems");
                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                
			}
			catch(Exception)
            {
                throw;
            }
           
        }
    }
}
