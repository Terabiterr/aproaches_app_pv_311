using System;
using System.Linq;

namespace approaches_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            var product = new Product
            {
                Name = "TV",
                Price = 15000.00m
            };
            //Create(product);
            Read();
        }
        public static void Read()
        {
            //Read
            using (var db = new ShopEntities())
            {
                var products = db.Products.ToList();
                foreach (var p in products)
                {
                    Console.WriteLine($"Id: {p.id}, Name: {p.Name}, Price: {p.Price}");
                }
            }
        }
        public static void Create(Product product)
        {
            using (var db = new ShopEntities())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
        public static void Update(int id, Product product)
        {
            using (var db = new ShopEntities())
            {
                var product_to_update = db.Products.Find(id);
                if (product_to_update != null)
                {
                    product_to_update.Name = product.Name;
                    product_to_update.Price = product.Price;
                    db.SaveChanges();
                }
            }
        }
        public static void Delete(int id)
        {
            using (var db = new ShopEntities())
            {
                var product = db.Products.Find(id);
                if(product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }
    }
}
