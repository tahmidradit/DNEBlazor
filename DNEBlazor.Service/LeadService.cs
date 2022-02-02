using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Repository.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Service
{
    public class LeadService : ILead
    {
        private readonly ApplicationDbContext context;

        public LeadService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Lead Add(Lead lead)
        {
            context.Leads.Add(lead);
            context.SaveChanges();
            return lead;
        }

        public string Delete(int Id)
        {
            var findById = context.Leads.FirstOrDefault(m => m.Id == Id);
            context.Leads.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public async Task<Lead> GetLead(int Id)
        {
            var findById = await context.Leads.FirstOrDefaultAsync(m => m.Id == Id);
            return findById;
        }

        public List<Lead> ToListLeads()
        {
            var leads = context.Leads.Include(m => m.Category).ToList();
            return leads;
        }

        public async Task<Lead> Update(Lead lead, AuthenticationStateProvider authenticationStateProviderInjected)
        {
            var authenticationStateProviderAsync = await authenticationStateProviderInjected.GetAuthenticationStateAsync();
            var user = authenticationStateProviderAsync.User.Claims;
            var findById = await context.Leads.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == lead.Id);
            findById.FirstName = lead.FirstName;
            findById.LastName = lead.LastName;
            findById.Email = lead.Email;
            findById.Phone = lead.Phone;
            findById.CategoryId = lead.CategoryId;
            findById.CreatedByUserId = user.FirstOrDefault().Value;
            findById.UpdatedByUserId = user.FirstOrDefault().Value;
            findById.DateCreated = lead.DateCreated;
            findById.DateUpdated = lead.DateUpdated;
            await context.SaveChangesAsync();
            return lead;
        }

        public List<Category> RenderCategoriesList()
        {
            return context.Categories.ToList();
        }
    }
}
