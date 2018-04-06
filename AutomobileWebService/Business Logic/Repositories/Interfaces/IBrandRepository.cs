using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Interfaces
{
    public interface IBrandRepository
    {
         Task<Brand> GetAsync(int id);
         Task<Brand> GetAsync(string name = null);
         Task<IQueryable<Brand>> BrowseAsync(string name = null);
         Task CreateAsync(Brand brand);
         Task UpdateAsync(Brand brand);
         Task DeleteAsync(Brand brand);
    }
}