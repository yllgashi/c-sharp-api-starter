using models;
using repository.Products;

namespace services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<Product> GetProducts()
        {
            return _productsRepository.GetProducts();
        }
    }
}
