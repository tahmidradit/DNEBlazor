using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Data.Models.Ecom
{
    public class ProductEcom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }
        public ProductCategory ProductCategory { get; set; }

        [ForeignKey("ProductCategoryId")]
        public int ProductCategoryId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
    }
}
