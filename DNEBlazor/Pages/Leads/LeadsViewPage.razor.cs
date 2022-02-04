using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNEBlazor.Pages.Leads
{
    public class LeadsViewPageModel : ComponentBase
    {
        [Inject]
        public ILead iLead { get; set; }

        [Inject]
        protected AuthenticationStateProvider authenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public Lead Lead = new Lead();

        public List<Lead> LeadsList => iLead.ToListLeads();
        public void Remove(int Id)
        {
            string delete = iLead.Delete(Id);
        }
        public async Task Save()
        {
            if (Lead.Id == 0)
            {
                Lead = iLead.Add(Lead);
            }
            else
            {
                Lead = await iLead.Update(Lead, authenticationStateProvider);
            }
        }

        //private void PreloadInputFields(Lead leadDM)
        //{
        //    Lead = leadDM;
        //}
    }
}
