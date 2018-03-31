using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutomobileWebService.Business_Logic.Models;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    public class CompanyNotValidData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "", null };
        }
    }
}