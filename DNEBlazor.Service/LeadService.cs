using DNEBlazor.Data.Models;
using DNEBlazor.Repository;
using DNEBlazor.Repository.Data;
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
            return this.GetLead(lead.Id);
        }

        public string Delete(int Id)
        {
            var findById = context.Leads.FirstOrDefault(m => m.Id == Id);
            context.Leads.Remove(findById);
            context.SaveChanges();
            return "Deleted";
        }

        public Lead GetLead(int Id)
        {
            var findById = context.Leads.FirstOrDefault(m => m.Id == Id);
            return findById;
        }

        public List<Lead> ToListLeads()
        {
            var leads = context.Leads.Include(m => m.Category).ToList();
            return leads;
        }

        public Lead Update(Lead lead)
        {
            context.Leads.Update(lead);
            context.SaveChanges();
            return this.GetLead(lead.Id);
        }

        public IEnumerable<Category> RenderCategoriesList()
        {
            return context.Categories.ToList();
        }
    }
}
