using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models.Dtos;
using ShopOnlineApi.Data.Repository.Contracts;
using ShopOnlineApi.Extensions;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository; 
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("getitems")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems() {
            try
            {
                var products = await _productRepository.GetItems();
                var productCategories = await _productRepository.GetItemsCategories();
                if (products == null || productCategories == null) return NotFound();
                else
                {
                    var productsDto = products.ConvertToDto(productCategories);
                    return Ok(productsDto);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("getitem/{id:int}", Name ="GetItemById")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            var product = await _productRepository.GetItem(id);
            var productCategory = await _productRepository.GetItemCategory(product.CategoryId);
            if (product == null || productCategory == null) return NotFound();

            var productDto = product.ConvertToDto(productCategory);
            return Ok(productDto);

        }
    }
}
