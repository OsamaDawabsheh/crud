using crud.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbcontext = new ApplicationDbContext();

            // add data

            List<Product>  a = new List<Product>()
            {
                new Product
                {
                    Name = "laptop",
                    Price = 1500
                },
                new Product
                {
                    Name = "smartphone",
                    Price = 1000
                },
                new Product
                {
                    Name = "headphone",
                    Price = 500
                }
            };

            var b = new List<Order>()
            {
                new Order
                {
                    Address = "Al-Quds Street, Nablus",
                    CreatedAt = DateTime.Now
                },
                new Order
                {
                    Address = "Rafidya Main Street, Nablus",
                    CreatedAt = DateTime.Now

                },
                new Order
                {
                    Address = "Al-Irsal Street, Ramallah",
                    CreatedAt = DateTime.Now
                }
            };

            dbcontext.products.AddRange(a);
            dbcontext.orders.AddRange(b);
            dbcontext.SaveChanges();

            // show data

            var c = dbcontext.products.ToList();
            var d = dbcontext.orders.ToList();

            Console.WriteLine("===== Products =====");
            Console.WriteLine("Name   Price");

            foreach (var product in c)
            {
                Console.WriteLine($"{product.Name}   {product.Price}");
            }

            Console.WriteLine("===== Orders =====");
            Console.WriteLine("Address   CreatedAt");

            foreach (var order in d)
            {
                Console.WriteLine($"{order.Address}   {order.CreatedAt}");
            }

            // update data

            var f = dbcontext.products.First(e => e.Id == 1);
            var g = dbcontext.orders.First(e => e.Id == 1);

            f.Name = "computer";
            g.CreatedAt = DateTime.Now;

            dbcontext.SaveChanges();

            // remove data

            var h = dbcontext.products.First(e => e.Id == 2);
            var i = dbcontext.orders.First(e => e.Id == 3);

            dbcontext.products.Remove(h);
            dbcontext.orders.Remove(i);

            dbcontext.SaveChanges();

        }




    }
}
