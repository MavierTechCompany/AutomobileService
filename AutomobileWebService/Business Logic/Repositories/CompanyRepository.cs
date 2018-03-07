using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.DAL;

namespace AutomobileWebService.Business_Logic.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private AutomobileContext _context { get; set; }

        public CompanyRepository(AutomobileContext context)
        {
            _context = context;
        }

        public async Task<Company> GetAsync(int id)
            => await Task.FromResult(_context.Companies.SingleOrDefault(x => x.Id == id && x.Deleted == false));

        public async Task<Company> GetAsync(string name)
            => await Task.FromResult(_context.Companies.SingleOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant() && x.Deleted == false));

        public async Task<Company> GetByPhoneNumberAsync(string phoneNumber)
            => await Task.FromResult(_context.Companies.SingleOrDefault(x => x.Phone.ToLowerInvariant() == phoneNumber.ToLowerInvariant() && x.Deleted == false));

        public async Task<IEnumerable<Company>> BrowseAsync(string name = null)
        {
            var companies = _context.Companies.Where(x => x.Deleted == false).AsEnumerable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                companies = companies.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(companies);
        }

        public async Task CreateAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            await Task.FromResult(_context.Companies.Update(company));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            company.Delete();
            await Task.FromResult(_context.Companies.Update(company));
            await _context.SaveChangesAsync();
        }
    }
}
