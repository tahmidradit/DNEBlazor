using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Data.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
