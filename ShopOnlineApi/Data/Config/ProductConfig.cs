using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnlineApi.Entities;

namespace ShopOnlineApi.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasData(new List<Product>()
            {
                new Product { Id = 1, Name = "TCL Smart Screen", Description ="4K with HD Graphics", ImageURL="Images/Electronics/image1.png", Price = 1500, Qty=1, CategoryId=1},
                new Product { Id = 2, Name = "SamSung Smart Screen", Description ="4K with HD Graphics", ImageURL="Images/Electronics/image2.png", Price = 2500, Qty=1, CategoryId=1},
                new Product { Id = 3, Name = "Sony Smart Screen", Description ="4K with HD Graphics", ImageURL="Images/Electronics/image3.png", Price = 1500, Qty=1, CategoryId=1},

                //Funiture Category
                new Product { Id = 4, Name = "King Size Bed", Description ="Double bed for master bedroom", ImageURL="Images/Furniture/image1.png", Price = 1500, Qty=1, CategoryId=2},
                new Product { Id = 5, Name = "Customize Living Room Sofa", Description ="Modern sofa for living room", ImageURL="Images/Furniture/image2.png", Price = 7500, Qty=1, CategoryId=2}
            });
        }
    }
}
