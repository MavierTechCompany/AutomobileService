using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.DAL;

namespace AutomobileWebService.Business_Logic.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private AutomobileContext _context { get; set; }

        public BrandRepository(AutomobileContext context)
        {
            _context = context;
        }

        public async Task<Brand> GetAsync(int id)
            => await Task.FromResult(_context.Brands.SingleOrDefault(x => x.Id == id));

        public async Task<Brand> GetAsync(string name)
            => await Task.FromResult(_context.Brands.SingleOrDefault(x =>
            x.Name.ToLowerInvariant() == name.ToLowerInvariant()));

        public async Task CreateAsync(Brand brand)
        {

        }

        public async Task UpdateAsync(Brand brand)
        {

        }

        public async Task DeleteAsync(Brand brand)
        {

        }
    }
}