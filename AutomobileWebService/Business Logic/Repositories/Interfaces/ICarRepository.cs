using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetAsync(int id);
        Task<Car> GetAsync(string brandName, string model, int generation);
        Task<IQueryable<Car>> BrowseAsync(string brand = null);
        Task<IQueryable<Car>> BrowseAsync(int? horsepower = null);
        Task<IQueryable<Car>> BrowseAsync(DateTime? productionDate = null);
        Task CreateAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Car car);
    }
}
