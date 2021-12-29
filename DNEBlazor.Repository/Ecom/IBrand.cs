using DNEBlazor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Repository.Ecom
{
    public interface IBrand
    {
        public Brand Add(Brand brand);
        public Brand Update(Brand brand);
        public string Delete(int Id);
        public Brand GetBrand(int Id);
        public List<Brand> ToListBrand();
    }
}
