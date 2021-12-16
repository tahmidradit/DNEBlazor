using DNEBlazor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Repository
{
    public interface IProduct
    {
        public Product Add(Product Product);
        public Product Update(Product Product);
        public string Delete(int id);
        public Product GetProducts(int id);
        public List<Product> ToListProducts();
    }
}
