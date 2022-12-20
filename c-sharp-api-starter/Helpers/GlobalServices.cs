using repository.Products;
using services.Products;

namespace c_sharp_api_starter.Helpers
{
    internal class GlobalServices
    {
        public static void AddDefaultServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
        }

        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
        }

        public static void UseDevelopmentMiddlewares(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void UseMiddlewares(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }

        public static void AddTransientDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProductsService, ProductsService>();
            builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
        }
    }
}
