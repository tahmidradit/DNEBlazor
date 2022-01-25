﻿using DNEBlazor.Data.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNEBlazor.Repository
{
    public interface ILead
    {
        public Lead Add(Lead lead);
        public Task<Lead> Update(Lead lead, AuthenticationStateProvider authenticationStateProviderInjected);
        public string Delete(int Id);
        public Lead GetLead(int Id);
        public List<Lead> ToListLeads();
    }
}
