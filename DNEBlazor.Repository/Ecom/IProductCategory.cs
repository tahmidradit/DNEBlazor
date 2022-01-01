using DNEBlazor.Data.Models;
using DNEBlazor.Data.Models.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Repository.Ecom
{
    public interface IProductCategory
    {
        public ProductCategory Add(ProductCategory productCategory);
        public ProductCategory Update(ProductCategory productCategory);
        public string Delete(int Id);
        public ProductCategory GetProductCategory(int Id);
        public List<ProductCategory> ToListProductCategory();
    }
}
