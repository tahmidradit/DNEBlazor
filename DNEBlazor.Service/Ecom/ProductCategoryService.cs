using DNEBlazor.Data.Models;
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
    public class ProductCategoryService : IProductCategory
    {
        private readonly ApplicationDbContext context;

        public ProductCategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            context.ProductCategories.Add(productCategory);
            context.SaveChanges();
            return this.GetProductCategory(productCategory.Id);
        }

        public string Delete(int Id)
        {
            var findById = context.ProductCategories.FirstOrDefault(m => m.Id == Id);
            context.ProductCategories.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public ProductCategory GetProductCategory(int Id)
        {
            var findById = context.ProductCategories.FirstOrDefault(m => m.Id == Id);
            return findById;
        }

        public List<ProductCategory> ToListProductCategory()
        {
            var productCategories = context.ProductCategories.ToList();
            return productCategories;
        }

        public ProductCategory Update(ProductCategory productCategory)
        {
            context.ProductCategories.Update(productCategory);
            context.SaveChanges();
            return this.GetProductCategory(productCategory.Id);
        }

        public List<ProductCategory> RenderProductCategoriesList()
        {
            return context.ProductCategories.ToList();
        }

        public List<Brand> RenderBrandsList()
        {
            return context.Brands.Include(m => m.ProductCategory).ToList();
        }
    }
}
