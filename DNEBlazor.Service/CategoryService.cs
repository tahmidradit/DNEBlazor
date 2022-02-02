using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Repository.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DNEBlazor.Service
{
    public class CategoryService : ICategory
    {
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        private readonly ApplicationDbContext context;
        private readonly AppDbContext dbContext;

        public CategoryService(ApplicationDbContext context, AppDbContext dbContext)
        {
            this.context = context;
            this.dbContext = dbContext;
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
            var findById = dbContext.Categories.FirstOrDefault(m => m.Id == Id);
            return findById;
        }

        public List<Category> ToListCategories()
        {
            var categories = dbContext.Categories.ToList();
            return categories;
        }

        public async Task<Category> Update(Category Category, AuthenticationStateProvider authenticationStateProviderInjected)
        {
            var authenticationStateProviderAsync = await authenticationStateProviderInjected.GetAuthenticationStateAsync();
            var user = authenticationStateProviderAsync.User.Claims;
            var findById = await context.Categories.FirstOrDefaultAsync(m => m.Id == Category.Id);
            findById.Name = Category.Name;
            findById.UpdatedByUserId = user.FirstOrDefault().Value;
            findById.CreatedByUserId = user.FirstOrDefault().Value;
            findById.DateUpdated = Category.DateUpdated;
            findById.DateCreated = Category.DateCreated;
            await context.SaveChangesAsync();
            return this.GetCategory(Category.Id);
        }
    }
}
