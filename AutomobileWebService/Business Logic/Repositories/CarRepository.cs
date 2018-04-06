using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.DAL;

namespace AutomobileWebService.Business_Logic.Repositories
{
    public class CarRepository : ICarRepository
    {
        private AutomobileContext _context { get; set; }

        public CarRepository(AutomobileContext context)
        {
            _context = context;
        }

        public async Task<Car> GetAsync(int id)
            => await Task.FromResult(_context.Cars.SingleOrDefault(x => x.Id == id &&
                x.Deleted == false));

        public async Task<Car> GetAsync(string brandName, string model, int generation)
            => await Task.FromResult(_context.Cars.SingleOrDefault(x =>
            x.BrandName.ToLowerInvariant() == brandName.ToLowerInvariant() &&
            x.Model.ToLowerInvariant() == model.ToLowerInvariant() &&
            x.Generation == generation && x.Deleted == false));

        public async Task<IQueryable<Car>> BrowseAsync(string brand = null)
        {
            var cars = _context.Cars.Where(x => x.Deleted == false).AsQueryable();

            if (!string.IsNullOrWhiteSpace(brand))
            {
                cars = cars.Where(x => x.BrandName.ToLowerInvariant().
                    Contains(brand.ToLowerInvariant()));
            }

            return await Task.FromResult(cars);
        }

		public async Task<IQueryable<Car>> BrowseAsync(int? horsepower = null)
        {
            var cars = _context.Cars.Where(x => x.Deleted == false).AsQueryable();
            if (horsepower != null)
            {
                cars = cars.Where(x => x.Horsepower == horsepower).AsQueryable();
            }

            return await Task.FromResult(cars);
        }

        public async Task<IQueryable<Car>> BrowseAsync(DateTime? productionDate = null)
        {
            var cars = _context.Cars.Where(x => x.Deleted == false).AsQueryable();
            if (productionDate != null)
            {
                cars = cars.Where(x => x.ProdutionDate == productionDate);
            }

            return await Task.FromResult(cars);
        }

        public async Task CreateAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Car car)
        {
            await Task.FromResult(_context.Cars.Update(car));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            car.Delete();
            await Task.FromResult(_context.Cars.Update(car));
            await _context.SaveChangesAsync();
        }
    }
}
