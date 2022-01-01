using DNEBlazor.Data.Models.Ecom;
using DNEBlazor.Repository.Data;
using DNEBlazor.Repository.Ecom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Service.Ecom
{
    public class ProductEcomServices : IProductEcom
    {
        private readonly ApplicationDbContext context;

        public ProductEcomServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ProductEcom Add(ProductEcom productEcom)
        {
            context.ProductsEcom.Add(productEcom);
            context.SaveChanges();
            return this.GetProduct(productEcom.Id);
        }

        public string Delete(int Id)
        {
            var findById = context.ProductsEcom.FirstOrDefault(m => m.Id == Id);
            context.ProductsEcom.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public ProductEcom GetProduct(int Id)
        {
            var findById = context.ProductsEcom.FirstOrDefault(m => m.Id == Id);
            return findById;
        }

        public List<ProductEcom> ToListProducts()
        {
            var productsEcom = context.ProductsEcom.Include(m => m.ProductCategory).Include(m => m.Brand).ToList();
            return productsEcom;
        }

        public ProductEcom Update(ProductEcom productEcom)
        {
            context.ProductsEcom.Update(productEcom);
            context.SaveChanges();
            return this.GetProduct(productEcom.Id);
        }
    }
}
