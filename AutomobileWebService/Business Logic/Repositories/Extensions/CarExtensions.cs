using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Extensions
{
    public static class CarExtensions
    {
        public static async Task<Car> GetOrFailAsync(this ICarRepository repository, int id)
        {
            var car = await repository.GetAsync(id);

            if (car == null)
            {
                throw new NullResponseException($"There is no car with id: {id}.");
            }

            return await Task.FromResult(car);
        }

        public static async Task<Car> GetOrFailAsync(this ICarRepository repository, string brandName, string model, int generation)
        {
            var car = await repository.GetAsync(brandName, model, generation);

            if (car == null)
            {
                throw new NullResponseException($"There is no car with given arguments.");
            }

            return await Task.FromResult(car);
        }

        public static async Task<IQueryable<Car>> BrowseOrFailAsync(this ICarRepository repository, string brand = null)
        {
            var cars = await repository.BrowseAsync(brand);

            if (cars == null)
            {
                throw new NullResponseException($"There isn't any car with brand: {brand}");
            }

            return await Task.FromResult(cars);
        }

        public static async Task<IQueryable<Car>> BrowseOrFailAsync(this ICarRepository repository, int? horsepower = null)
        {
            var cars = await repository.BrowseAsync(horsepower);

            if (cars == null)
            {
                throw new NullResponseException($"There isn't any car with horsepower: {horsepower}");
            }

            return await Task.FromResult(cars);
        }

        public static async Task<IQueryable<Car>> BrowseOrFailAsync(this ICarRepository repository, DateTime? productionDate = null)
        {
            var cars = await repository.BrowseAsync(productionDate);

            if (cars == null)
            {
                throw new NullResponseException($"There isn't any car with production date: {productionDate}");
            }

            return await Task.FromResult(cars);
        }

        public static async Task CreateOrFailAsnc(this ICarRepository repository, Car _car)
        {
            var car = await repository.GetAsync(_car.BrandName, _car.Model, _car.Generation);

            if (car == _car)
            {
                throw new ForbiddenValueException($"That car already exists.");                
            }

            await repository.CreateAsync(_car);
        }

        public static async Task UpdateOrFailAsync(this ICarRepository repository, Car _car)
        {
            var car = await repository.GetAsync(_car.Id);

            if (car == null)
            {
                throw new NullResponseException($"There isn't any car with ID: {_car.Id}");   
            }

            await repository.UpdateAsync(_car);
        }

        public static async Task DeleteOrFailAsync(this ICarRepository repository, int id)
        {
            var car = await repository.GetAsync(id);

            if (car == null)
            {
                throw new NullResponseException($"There isn't any car with ID: {id}");
            }

            await repository.DeleteAsync(car);
        }
    }
}
