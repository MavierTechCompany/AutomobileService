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
        [Required]
        public string ProjectName { get; protected set; }
        [Required]
        public string Category { get; protected set; }
        [Required]
        public int Horsepower { get; protected set; }
        [Required]
        public float TopSpeedInKilometers { get; protected set; }
        [Required]
        public float TopSpeedInMiles { get; protected set; }
        [Required]
        public float ZeroToHundreds { get; protected set; }
        [Required]
        public float ZeroToSixty { get; protected set; }
        [Required]
        public string EngineModel { get; protected set; }
        [Required]
        public bool HasTurbochager { get; protected set; }
        [Required]
        public bool HasSupercharger { get; protected set; }
        [Required]
        public Guid CarId { get; protected set; }
        [Required]
        public Guid UserId { get; protected set; }

        //zdjęcie projektu

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }

        //wiele do wielu z userami - tabela pośrednia

        protected Project()
        {

        }

        public Project(Guid id, string projectName, string category, int horsepower, float topSpeedInKilometers, float topSpeedInMiles,
            float zeroToHundreds, float zeroToSixty, string engineModel, bool hasTurbocharger, bool hasSupercharger, Car car, User user)
        {
            Id = id;
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
            SetZeroToSixty(zeroToSixty);
            SetEngineModel(engineModel);            
        }

        #region Public

        public void Update(int horsepower, float topSpeedInKilometers, float topSpeedInMiles, float zeroToHundreds,
            float zeroToSixty, string engineModel, bool hasTurbocharger, bool hasSupercharger)
        {
            HasTurbochager = hasTurbocharger;
            HasSupercharger = hasSupercharger;

            SetHorsepower(horsepower);
            SetTopSpeedInKilometers(topSpeedInKilometers);
            SetTopSpeedInMiles(topSpeedInMiles);
            SetZeroToHundreds(zeroToHundreds);
            SetZeroToSixty(zeroToSixty);
            SetEngineModel(engineModel);
        }

        public static Project Delete(Project project)
        {
            project.Deleted = true;
            return project;
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

        private void SetZeroToSixty(float zeroToSixty)
        {
            if (zeroToSixty < 1.0)
            {
                throw new ForbiddenValueException($"Project with id {Id} can't have zero to sixty less than one!");
            }

            ZeroToSixty = zeroToSixty;
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
