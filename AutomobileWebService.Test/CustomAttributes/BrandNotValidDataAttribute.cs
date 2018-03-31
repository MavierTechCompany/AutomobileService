using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    class BrandNotValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "", new DateTime(), default(DateTime) };
        }
    }
}