using DNEBlazor.Data.Models;

namespace DNEBlazor.Repository
{
    public interface ICategory 
    {
        public Category Add(Category Category);
        public Category Update(Category category);
        public string Delete(int Id);
        public Category GetCategory(int Id);
        public List<Category> ToListCategories();
    }
}
