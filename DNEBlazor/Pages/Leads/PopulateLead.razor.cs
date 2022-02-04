using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNEBlazor.Pages.Leads
{
    public class PopulateLeadModel : ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider authenticationStateProvider { get; set; }

        [Inject]
        public ICategory iCategory { get; set; }

        [Inject]
        public ILead iLead { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public Lead Lead = new Lead();
        public List<Category> Categories => iCategory.ToListCategories();

        //[Parameter]
        //public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Lead = await iLead.GetLead(int.Parse(Id));
            var authenticationStateProviderAsync = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationStateProviderAsync.User.Claims;

            Lead = new Lead()
            {
                CreatedByUserId = user.FirstOrDefault().Value,
                UpdatedByUserId = user.FirstOrDefault().Value,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
        }
        public void Save()
        {
            

            Lead =  iLead.Add(Lead);
            navigationManager.NavigateTo("/leadsview");
        }

        public void Redirect()
        {
            navigationManager.NavigateTo("/leadsview");
        }
    }
}
