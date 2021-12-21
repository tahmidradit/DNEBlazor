using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DNEBlazor.Service
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext context;
        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Category Add(Category Category)
        {
            context.Categories.Add(Category);
            context.SaveChanges();
            return this.GetCategory(Category.Id);
        }

        public string Delete(int Id)
        {
            var findById = context.Categories.FirstOrDefault(m => m.Id == Id);
            context.Categories.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public Category GetCategory(int Id)
        {
            var findById = context.Categories.FirstOrDefault(m => m.Id == Id);
            return findById;
        }

        public List<Category> ToListCategories()
        {
            var categories = context.Categories.ToList();
            return categories;
        }

        public Category Update(Category Category)
        {
            context.Categories.Update(Category);
            context.SaveChanges();
            return this.GetCategory(Category.Id);
        }

        //Category ICategory.PreloadData()
        //{
        //    UserName = httpContextAccessor.HttpContext.User.Identity.Name;
        //    var user = userManager.FindByNameAsync(UserName);
        //    var userId = user.Id;

        //    Category catVM = new Category()
        //    {
        //        CreatedByUserId = userId.ToString(),
        //        UpdatedByUserId = userId.ToString(),
        //        DateCreated = DateTime.Now,
        //        DateUpdated = DateTime.Now
        //    };
        //    return catVM;
        //}
    }
}
