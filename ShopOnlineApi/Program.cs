
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using ShopOnlineApi.Data;
using ShopOnlineApi.Data.Repository;
using ShopOnlineApi.Data.Repository.Contracts;
using System.Net.Mime;

namespace ShopOnlineApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ShopOnlineDBContext>(options => options.UseNpgsql(
                builder.Configuration.GetConnectionString("ShopOnlineConnection")
                ));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

			app.UseCors(options =>
                      options.WithOrigins("http://localhost:7054", "https://localhost:7054")
                      .AllowAnyMethod()
                      .WithHeaders(HeaderNames.ContentType)
                );

			app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
