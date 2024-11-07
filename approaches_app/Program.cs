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
        //Read
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
            //Create
            using (var db = new ShopEntities())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
