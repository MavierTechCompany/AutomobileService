using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutomobileWebService.Business_Logic.Models;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    public class ProjectNotValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { null, null, 0, 0.00, 0.00, 0.0, null, false, false };
        }
    }
}