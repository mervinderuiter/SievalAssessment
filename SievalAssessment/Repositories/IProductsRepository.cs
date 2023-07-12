using SievalAssessment.Models;

namespace SievalAssessment.Repositories
{
    public interface IProductsRepository
    {
        public List<Product> GetProducts();
        public Product? GetProduct(int id);
        public bool DeleteProduct(int id);
        bool AddProduct(ProductDTO product);
        bool UpdateProduct(int id, ProductDTO product);
    }
}
