using BlazorInputFile;
using DNEBlazor.Data.Models.Ecom;
using DNEBlazor.Repository.Data;
using DNEBlazor.Repository.Ecom;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DNEBlazor.Service.Ecom
{
    public class ProductEcomServices : IProductEcom
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        IFileListEntry[] fn;

        public ProductEcomServices(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            
        }

        public ProductEcom Add(ProductEcom productEcom, IFileListEntry file, int Id)
        {
            context.ProductsEcom.Add(productEcom);
            context.SaveChanges();

            //System.IO.File.Copy(uploads, webRootPath + @"\images\" + menuItemByIdViewModel + ".png")
            //string webRootPath = webHostEnvironment.WebRootPath;
            //var uploads = Path.Combine(webRootPath, @"images\" + productEcom.Id.ToString());
            //var files = fn.FirstOrDefault();
            //var uploads = Path.Combine(webRootPath, "images");
            //var findProductsById = context.ProductsEcom.Find(productEcom.Id);
            //var path = Path.Combine(_environment.ContentRootPath, "Upload", fileEntry.Name);
            //var path = Path.Combine(uploads, file.Name);
            //files has been uploaded

            //var extension = System.IO.Path.GetExtension(file.Name);
            //var memoryStream = new MemoryStream();
            //using (FileStream filesStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            //{
            //    memoryStream.WriteTo(filesStream);

            //}
            //findProductsById.Picture = @"\images\" + productEcom.Id ;




            //var webRootPath = webHostEnvironment.WebRootPath;
            //var files = httpContext.Request.Form.Files;
            //var productId = context.ProductsEcom.Find(productEcom.Id);
            //var findById = context.ProductsEcom.Find(Id);
            //var path = Path.Combine(webHostEnvironment.ContentRootPath, "Upload", files);
            //var memoryStream = new MemoryStream();
            //file.Data.CopyTo(memoryStream);
            //using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            //{
            //    memoryStream.WriteTo(fileStream);
            //} 

            //var path = Path.Combine(webHostEnvironment.WebRootPath, "Upload", file.Name);
            //var memoryStream = new MemoryStream();
            //file.Data.CopyTo(memoryStream);
            //using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            //{
            //    memoryStream.WriteTo(fileStream);
            //}

            //productId.Picture = @"\Upload\" + productId ;


            //else
            //{
            //var uploads = Path.Combine(webRootPath, @"images\" + StaticDetail.DefaultImage);
            //System.IO.File.Copy(uploads, webRootPath + @"\images\" + menuItemByIdViewModel + ".png");
            //findMenuItemById.Image = @"\image\" + menuItemByIdViewModel + ".png";
            //}



            //var memoryStream = new MemoryStream();
            //await file.Data.CopyToAsync(memoryStream);
            //using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            //{
            //    memoryStream.WriteTo(fileStream);
            //}


            //var path = Path.Combine(webHostEnvironment.ContentRootPath, "Upload",);
            //var ms = new MemoryStream();
            //file.Data.CopyTo(ms);
            //using (FileStream files = new FileStream(path, FileMode.Create, FileAccess.Write))
            //{
            //    ms.WriteTo(files);
            //}

            return this.GetProduct(productEcom.Id);
        }

        public string Delete(int Id)
        {
            var findById = context.ProductsEcom.FirstOrDefault(m => m.Id == Id);
            context.ProductsEcom.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public ProductEcom GetProduct(int Id)
        {
            var findById = context.ProductsEcom.FirstOrDefault(m => m.Id == Id);
            return findById;
        }

        public List<ProductEcom> ToListProducts()
        {
            var productsEcom = context.ProductsEcom.Include(m => m.ProductCategory).Include(m => m.Brand).ToList();
            return productsEcom;
        }

        public ProductEcom Update(ProductEcom productEcom)
        {
            context.ProductsEcom.Update(productEcom);
            context.SaveChanges();
            return this.GetProduct(productEcom.Id);
        }

        public async Task UploadImages(IFileListEntry file)
        {
            var path = Path.Combine(webHostEnvironment.ContentRootPath, "Upload", file.Name);
            var memoryStream = new MemoryStream();
            await file.Data.CopyToAsync(memoryStream);
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}
