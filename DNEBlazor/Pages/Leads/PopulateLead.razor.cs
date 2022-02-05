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
        public Lead lead { get; set; }
        public List<Category> Categories => iCategory.ToListCategories();

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var authenticationStateProviderAsync = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationStateProviderAsync.User.Claims;

            Lead = new Lead()
            {
                CreatedByUserId = user.FirstOrDefault().Value,
                UpdatedByUserId = user.FirstOrDefault().Value,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            //if (Id != 0)
            //{
            //    var getLead = await iLead.GetLead(Id);
            //    Lead = getLead;
            //}
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != 0)
            {
                var getLead = await iLead.GetLead(Id);
                Lead = getLead;
            }
        }
        public async Task SaveAsync()
        {
            if(Lead.Id == 0)
            {
                Lead = await iLead.Add(Lead);
                navigationManager.NavigateTo("/leadsview");
            }

            else
            {
                Lead = await iLead.Update(Lead, authenticationStateProvider);
                navigationManager.NavigateTo("/leadsview");
            }
        }

        public void Redirect()
        {
            navigationManager.NavigateTo("/leadsview");
        }
    }
}
