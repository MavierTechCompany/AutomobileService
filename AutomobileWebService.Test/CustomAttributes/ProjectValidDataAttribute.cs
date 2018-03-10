using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    public class ProjectValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {"Project X", "Classic", 210, 100.00, 60.00, 5.4, "F22H", true, true};
        }
    }
}