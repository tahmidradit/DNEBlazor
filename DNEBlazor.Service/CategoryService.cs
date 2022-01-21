using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Repository.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

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

        [Inject]
        protected AuthenticationStateProvider authenticationStateProvider { get; set; }

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

        
        //public async Task InsertUserIds()
        //{
        //    //var authenticationStateProviderAsync = await authenticationStateProvider.GetAuthenticationStateAsync();
        //    var user = (await authenticationStateProvider.GetAuthenticationStateAsync()).User.Claims;
        //    var cat = new Category()
        //    {
        //        CreatedByUserId = user.FirstOrDefault().Value,
        //        UpdatedByUserId = user.FirstOrDefault().Value
        //    };
            
        //    await context.Categories.AddAsync(cat);
        //    await context.SaveChangesAsync();
        //}
    }
}
