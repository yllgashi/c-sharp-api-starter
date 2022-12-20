using models;

namespace repository.Products
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public List<Product> GetProducts()
        {
            return new List<Product> { new Product { Id = 1, Name = "Product1", Price = 10 }, new Product { Id = 2, Name = "Product2", Price = 20 } };
        }
    }
}
