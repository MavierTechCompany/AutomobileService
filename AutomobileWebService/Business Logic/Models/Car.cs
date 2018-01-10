using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public class Car : Entity
    {
        [Required]
        public string BrandName { get; protected set; }
        [Required]
        public string Model { get; protected set; }
        [Required]
        public int Horsepower { get; protected set; }
        [Required]
        public int Generation { get; protected set; }
        [Required]
        public DateTime ProdutionDate { get; protected set; }
        [Required]
        public Guid BrandId { get; protected set; }

        public virtual Brand Brand { get; set; }
        public virtual List<Project> Projects { get; set; }

        protected Car()
        {

        }

        public Car(Guid id, string model, int horsepower, int generation, DateTime productionDate, Brand brand)
        {
            Id = id;

            SetBrandName(brand.Name);
            SetModel(model);
            SetHorsepower(horsepower);
            SetGeneration(generation);
            SetProductionDate(productionDate);

            BrandId = brand.Id;
        }

        public void Update(string model, int horsepower, int generation, DateTime productionDate)
        {
            SetModel(model);
            SetHorsepower(horsepower);
            SetGeneration(generation);
            SetProductionDate(productionDate);
        }

        private void SetBrandName(string brandName)
        {
            if (string.IsNullOrWhiteSpace(brandName))
            {
                throw new ForbiddenValueException($"Car with id {Id} can not have an empty brand name");
            }
            BrandName = brandName;
        }

        private void SetModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ForbiddenValueException($"Car with id {Id} can not have an empty model");
            }
            Model = model;
        }

        private void SetHorsepower(int horsepower)
        {
            if (horsepower <= 0)
            {
                throw new ForbiddenValueException($"Car with id {Id} can not have horsepower less than one");
            }
            Horsepower = horsepower;
        }

        private void SetGeneration(int generation)
        {
            if (generation <= 0)
            {
                throw new ForbiddenValueException($"Car with id {Id} can not have generation less than one");
            }
            Generation = generation;
        }

        private void SetProductionDate(DateTime productionDate)
        {
            if (productionDate == default(DateTime))
            {
                throw new ForbiddenValueException($"Car with id {Id} can not have default production date.");
            }
            ProdutionDate = productionDate;
        }
    }
}
