using DNEBlazor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Repository
{
    public interface ICategory 
    {
        public Category Add(Category category);
        public Category Update(Category category);
        public string Delete(int Id);
        public Category GetCategory(int Id);
        public List<Category> ToListCategories();
    }
}
