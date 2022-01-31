using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace DNEBlazor.Pages.Leads
{
    public class LeadsViewPageModel : ComponentBase
    {
        [Inject]
        public ILead iLead { get; set; }

        public Lead Lead = new Lead();

        public List<Lead> LeadsList => iLead.ToListLeads();
    }
}
