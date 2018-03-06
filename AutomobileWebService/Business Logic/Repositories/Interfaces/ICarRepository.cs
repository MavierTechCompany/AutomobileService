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
        Task<Car> GetAsync(Guid id);
        Task<Car> GetAsync(string brandName, string model, int generation);
        Task<IEnumerable<Car>> BrowseAsync(string brand = null);
        Task<IEnumerable<Car>> BrowseAsync(int? horsepower = null);
        Task<IEnumerable<Car>> BrowseAsync(DateTime? productionDate = null);
        Task CreateAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Car car);
    }
}
