﻿using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public class Brand : Entity
    {
        public string Name { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }

        public virtual List<Car> Cars { get; set; }

        protected Brand() { }

        public Brand(string name, DateTime startDate, DateTime? endDate) : base()
        {
            SetName(name);
            SetStartDate(startDate);
            SetEndDate(endDate);
        }

        public void Update(string name, DateTime startDate, DateTime? endDate)
        {
            SetName(name);
            SetStartDate(startDate);
            SetEndDate(endDate);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ForbiddenValueException($"Brand with id {Id} can not have an empty name.");
            }
            Name = name;
        }

        private void SetStartDate(DateTime startDate)
        {
            if (startDate == default(DateTime))
            {
                throw new ForbiddenValueException($"Brand with id {Id} can not have default start date.");
            }
            StartDate = startDate;
        }

        private void SetEndDate(DateTime? endDate)
        {
            if (endDate == default(DateTime))
            {
                throw new ForbiddenValueException($"Brand with id {Id} can not have default start date.");
            }
            EndDate = endDate;
        }
    }
}
