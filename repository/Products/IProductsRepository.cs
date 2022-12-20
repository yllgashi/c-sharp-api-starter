using models;

namespace repository.Products
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
    }
}
