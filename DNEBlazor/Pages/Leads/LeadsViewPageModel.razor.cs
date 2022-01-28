using DNEBlazor.Data.Models;
using DNEBlazor.Repository.Data;
using DNEBlazor.Service;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace DNEBlazor.Pages.Leads
{
    public class LeadsViewPageModel : ComponentBase
    {
        //public IEnumerable<Lead> LeadsEnum { get; set; }
        //protected List<Lead> LeadsList = new List<Lead>();
        protected List<Lead> LeadsList = new List<Lead>();
        protected IEnumerable<Category> CategoriesList { get; set; }
    }
}
