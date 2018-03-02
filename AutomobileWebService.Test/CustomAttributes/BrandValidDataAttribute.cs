using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    internal class BrandValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Brand1", new DateTime(1996, 10, 2), new DateTime?() };
        }
    }
}