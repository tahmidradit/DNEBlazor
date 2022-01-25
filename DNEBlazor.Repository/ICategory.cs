using DNEBlazor.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace DNEBlazor.Repository
{
    public interface ICategory 
    {
        public Category Add(Category Category);
        public Task<Category> Update(Category category, AuthenticationStateProvider authenticationStateProviderInjected);
        public string Delete(int Id);
        public Category GetCategory(int Id);
        public List<Category> ToListCategories();
    }
}
