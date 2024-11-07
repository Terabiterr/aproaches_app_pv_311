using approaches_app.Services;
using System;

namespace approaches_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ServiceProduct(new ShopEntities()))
            {
                db.CreateProduct(new Product { Name = "Xbox360", Price = 700.00m });
            }
            using (var db = new ServiceProduct(new ShopEntities()))
            {
                var products = db.GetProducts();
                foreach (var p in products)
                {
                    Console.WriteLine(p.Name);
                }
            }
        }
    }
}
