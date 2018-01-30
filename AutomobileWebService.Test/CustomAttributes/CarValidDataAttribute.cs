using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AutomobileWebService.Tests.CustomAttributes
{
    public class CarValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {"Model B", 500, 2, new DateTime(1998, 9, 15)};
        }
    }
}