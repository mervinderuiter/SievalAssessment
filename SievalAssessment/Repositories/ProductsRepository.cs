using System;
using SievalAssessment.Models;
using SievalAssessment.Repositories.Context;

namespace SievalAssessment.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        
        private ProductsContext _context = new ProductsContext();
        public ProductsRepository() {

            List<Product> products = new List<Product>
            {
                new Product()
                {
                    SKU = "h54hy6jghfdhg54u6",
                    Name = "Apple",
                    Price = 1.11
                },
                new Product()
                {
                    SKU = "ht654ytfh66",
                    Name = "Orange",
                    Price = 1.30
                },
                new Product()
                {
                    SKU = "h5666yhgrthrg54",
                    Name = "Banana",
                    Price = 0.80
                }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();

        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProduct(int id)
        {
            return _context.Products.SingleOrDefault(x => x.ID == id);
        }

        public bool AddProduct(ProductDTO productInput)
        {
            var product = new Product
            {
                SKU = productInput.SKU,
                Name = productInput.Name,
                Price = productInput.Price
            }; //Next time i'll use an auto mapper

            _context.Products.Add(product);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var record = _context.Products.SingleOrDefault(x => x.ID == id);
            if (record != null)
            {
                _context.Products.Remove(record);
                _context.SaveChanges();
                return true;
            } else
                return false;
        }

        public bool UpdateProduct(int id, ProductDTO product)
        {
            var record = _context.Products.SingleOrDefault(x => x.ID == id);
            if (record != null)
            {
                record.SKU = product.SKU;
                record.Name = product.Name;
                record.Price = product.Price;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
