using BlazorInputFile;
using DNEBlazor.Data.Models;
using DNEBlazor.Data.Models.Ecom;
using DNEBlazor.Repository.Data;
using DNEBlazor.Repository.Ecom;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Service.Ecom
{
    public class ProductCategoryService : IProductCategory
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public ProductCategoryService(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
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

        public IEnumerable<ProductCategory> RenderProductCategoriesList()
        {
            return context.ProductCategories.ToList();
        }

        public IEnumerable<Brand> RenderBrandsList()
        {
            return context.Brands.ToList();
        }

        public IEnumerable<ProductEcom> RenderProducts()
        {
            return context.ProductsEcom.Include(m => m.ProductCategory).Include(m => m.Brand).ToList();
        }

        public bool UploadImage(ProductEcom productEcom)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"Insert into ProductsEcom(Picture) Values('{productEcom.Picture}')";

                //using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                //{
                //    command.CommandType = CommandType.Text;
                //    sqlConnection.Open();
                //    command.ExecuteNonQuery();
                //    sqlConnection.Close();
                //}

                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }
            return true;
        }
    }
}
