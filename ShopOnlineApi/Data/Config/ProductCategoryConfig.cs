using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnlineApi.Entities;

namespace ShopOnlineApi.Data.Config
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");

            builder.HasData(new List<ProductCategory>()
            {
                new ProductCategory
                {
                    Id = 1,
                    Name = "Electronics",
                },
                new ProductCategory
                {
                    Id=2,
                    Name="Furniture"
                }
            });
        }
    }
}
