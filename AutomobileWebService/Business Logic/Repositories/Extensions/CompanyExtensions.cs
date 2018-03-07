using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Extensions
{
    public static class CommpanyExtensions
    {
        public static async Task<Company> GetOrFailAsync(this ICompanyRepository repository, int id)
        {
            var company = await repository.GetAsync(id);

            if (company == null)
            {
                throw new ForbiddenValueException($"There is no company with id: {id}.");
            }

            return await Task.FromResult(company);
        }
        
        public static async Task<Company> GetOrFailAsync(this ICompanyRepository repository, string name)
        {
            var company = await repository.GetAsync(name);

            if (company == null)
            {
                throw new ForbiddenValueException($"There is no company with name: {name}.");
            }

            return await Task.FromResult(company);
        }

        public static async Task<Company> GetByPhoneNumberOrFailAsync(this ICompanyRepository repository, string phoneNumber)
        {
            var company = await repository.GetByPhoneNumberAsync(phoneNumber);

            if (company == null)
            {
                throw new ForbiddenValueException($"There is no company with phone number: {phoneNumber}.");
            }

            return await Task.FromResult(company);
        }

        public static async Task<IEnumerable<Company>> BrowseOrFailAsync(this ICompanyRepository repository, string name = null)
        {
            var companies = await repository.BrowseAsync(name);

            if (companies == null)
            {
                throw new ForbiddenValueException($"There isn't any company with name: {name}.");
            }

            return await Task.FromResult(companies);
        }
    }
}
