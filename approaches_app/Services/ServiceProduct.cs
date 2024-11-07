using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace approaches_app.Services
{
    public interface IServiceProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
    public class ServiceProduct : IServiceProduct, IDisposable
    {
        private readonly ShopEntities _db;
        public ServiceProduct(ShopEntities db)
        {
            _db = db;
        }
        public void CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Product GetProductById(int id)
            => _db.Products.Find(id);

        public IEnumerable<Product> GetProducts()
            => _db.Products.ToList();

        public void UpdateProduct(int id, Product product)
        {
            var product_to_update = _db.Products.Find(id);
            if (product_to_update != null)
            {
                product_to_update.Name = product.Name;
                product_to_update.Price = product.Price;
                _db.SaveChanges();
            }
        }
    }
}
