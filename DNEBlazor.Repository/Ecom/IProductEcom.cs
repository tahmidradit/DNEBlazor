using BlazorInputFile;
using DNEBlazor.Data.Models.Ecom;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Repository.Ecom
{
    public interface IProductEcom
    {
        public ProductEcom Add(ProductEcom productEcom, IFileListEntry file, int Id);
        public ProductEcom Update(ProductEcom productEcom);
        public string Delete(int Id);
        public ProductEcom GetProduct(int Id);
        public List<ProductEcom> ToListProducts();

        Task UploadImages(IFileListEntry file);
    }
}
