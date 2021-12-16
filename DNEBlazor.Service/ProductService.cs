using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Service
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Product Add(Product Product)
        {
            context.Products.Add(Product);
            context.SaveChanges();
            return this.GetProducts(Product.Id);
        }

        public string Delete(int id)
        {
            var findById = context.Products.FirstOrDefault(m => m.Id == id);
            context.Products.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public Product GetProducts(int id)
        {
            var productsFindById = context.Products.FirstOrDefault(m => m.Id == id);
            return productsFindById;
        }

        public List<Product> ToListProducts()
        {
            var products = context.Products.ToList();
            return products;
        }

        public Product Update(Product Product)
        {
            context.Products.Update(Product);
            context.SaveChanges();
            return this.GetProducts(Product.Id);
        }
    }
}
