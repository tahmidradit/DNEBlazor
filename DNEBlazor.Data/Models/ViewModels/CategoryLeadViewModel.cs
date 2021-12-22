using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Data.Models.ViewModels
{
    public class CategoryLeadViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Lead Lead { get; set; }
    }
}
