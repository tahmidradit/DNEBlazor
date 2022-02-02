using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Repository.Data;
using DNEBlazor.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNEBlazor.Pages.Leads
{
    public class AddLeadModel : ComponentBase
    {
        [Inject]
        protected AuthenticationStateProvider authenticationStateProvider { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected ILead iLead { get; set; }

        [Inject]
        protected ICategory iCategory { get; set; }

        protected Lead lead = new Lead();

        //public List<Category> Categories => iCategory.ToListCategories();
        
        //public async Task Save()
        //{
        //    var authenticationStateProviderAsync = await authenticationStateProvider.GetAuthenticationStateAsync();
        //    var user = authenticationStateProviderAsync.User.Claims;

        //    lead = new Lead()
        //    {
        //        CreatedByUserId = user.FirstOrDefault().Value,
        //        UpdatedByUserId = user.FirstOrDefault().Value,
        //        DateCreated = DateTime.Now,
        //        DateUpdated = DateTime.Now
        //    };
 
        //    lead = await iLead.Add(lead);
        //    navigationManager.NavigateTo("/leadsview");

        //    lead = new Lead();

        //}

        public void Redirect()
        {
            navigationManager.NavigateTo("/leadsview");
        }



    }
}
