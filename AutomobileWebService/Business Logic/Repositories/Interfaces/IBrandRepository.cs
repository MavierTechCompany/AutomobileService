using AutomobileWebService.Business_Logic.Models;
using System;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Interfaces
{
    public interface IBrandRepository
    {
         Task<Brand> GetAsync(int id);
         Task<Brand> GetAsync(string name);

        //Browse/GetAll
         
         Task CreateAsync(Brand brand);
         Task UpdateAsync(Brand brand);
         Task DeleteAsync(Brand brand);
    }
}