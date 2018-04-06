using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetAsync(int id);
        Task<Company> GetAsync(string name);
        Task<Company> GetByPhoneNumberAsync(string phoneNumber);
        Task<IQueryable<Company>> BrowseAsync(string name = null);
        Task CreateAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Company company);
    }
}
