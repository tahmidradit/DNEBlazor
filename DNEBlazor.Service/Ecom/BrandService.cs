﻿using DNEBlazor.Data.Models;
using DNEBlazor.Repository.Data;
using DNEBlazor.Repository.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Service.Ecom
{
    public class BrandService : IBrand
    {
        private readonly ApplicationDbContext context;

        public BrandService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Brand Add(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
            return this.GetBrand(brand.Id);
        }

        public string Delete(int Id)
        {
            var findById = context.Brands.FirstOrDefault(m => m.Id == Id);
            context.Brands.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public Brand GetBrand(int Id)
        {
            var findById = context.Brands.FirstOrDefault(m => m.Id == Id);
            return findById;
        }

        public List<Brand> ToListBrand()
        {
            var brands = context.Brands.ToList();
            return brands;
        }

        public Brand Update(Brand brand)
        {
            context.Brands.Update(brand);
            context.SaveChanges();
            return this.GetBrand(brand.Id);
        }

        public IEnumerable<ProductCategory> RenderCategoriesList()
        {
            return context.ProductCategories.ToList();
        }
    }
}
