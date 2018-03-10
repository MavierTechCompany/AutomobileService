using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public class Project : Entity
    {
        public string ProjectName { get; protected set; }
        public string Category { get; protected set; }
        public int Horsepower { get; protected set; }
        public float TopSpeedInKilometers { get; protected set; }
        public float TopSpeedInMiles { get; protected set; }
        public float ZeroToHundreds { get; protected set; }
        public string EngineModel { get; protected set; }
        public bool HasTurbochager { get; protected set; }
        public bool HasSupercharger { get; protected set; }
        public int CarId { get; protected set; }
        public int UserId { get; protected set; }

        //zdjęcie projektu

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }

        //wiele do wielu z userami - tabela pośrednia

        protected Project()
        {

        }

        public Project(string projectName, string category, int horsepower,
            float topSpeedInKilometers, float topSpeedInMiles, float zeroToHundreds,
            string engineModel, bool hasTurbocharger, bool hasSupercharger,
            Car car, User user) : base()
        {
            CarId = car.Id;
            UserId = user.Id;
            HasTurbochager = hasTurbocharger;
            HasSupercharger = hasSupercharger;

            SetProjectName(projectName);
            SetCategory(category);
            SetHorsepower(horsepower);
            SetTopSpeedInKilometers(topSpeedInKilometers);
            SetTopSpeedInMiles(topSpeedInMiles);
            SetZeroToHundreds(zeroToHundreds);
            SetEngineModel(engineModel);      
        }

        #region Public

        public void Update(string projectName, string category, int horsepower,
            float topSpeedInKilometers, float topSpeedInMiles, float zeroToHundreds,
            string engineModel, bool hasTurbocharger, bool hasSupercharger)
        {
            HasTurbochager = hasTurbocharger;
            HasSupercharger = hasSupercharger;

            SetProjectName(projectName);
            SetCategory(category);
            SetHorsepower(horsepower);
            SetTopSpeedInKilometers(topSpeedInKilometers);
            SetTopSpeedInMiles(topSpeedInMiles);
            SetZeroToHundreds(zeroToHundreds);
            SetEngineModel(engineModel);  
        }

        #endregion

        #region Private

        private void SetProjectName(string projectName)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have an empty name!");
            }

            ProjectName = projectName;
        }

        private void SetCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have an empty category!");
            }

            Category = category;
        }

        private void SetHorsepower(int horsepower)
        {
            if (horsepower <= 0)
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have horsepower less than one!");
            }

            Horsepower = horsepower;
        }

        private void SetTopSpeedInKilometers(float topSpeedInKilometers)
        {
            if (topSpeedInKilometers < 1.0)
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have top speed in kilometers less than one!");
            }

            TopSpeedInKilometers = topSpeedInKilometers;
        }

        private void SetTopSpeedInMiles(float topSpeedInMiles)
        {
            if (topSpeedInMiles < 1.0)
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have top speed in miles less than one!");
            }

            TopSpeedInMiles = topSpeedInMiles;
        }

        private void SetZeroToHundreds(float zeroToHundreds)
        {
            if (zeroToHundreds < 1.0)
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have zero to hundreds less than one!");
            }

            ZeroToHundreds = zeroToHundreds;
        }

        private void SetEngineModel(string engineModel)
        {
            if (string.IsNullOrWhiteSpace(engineModel))
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have an empty engine model!");
            }

            EngineModel = engineModel;
        }

        #endregion
    }
}
