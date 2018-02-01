using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AutomobileWebService.Tests.CustomAttributes
{
    class CarNotValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "", -10, 0, new DateTime() };
        }
    }
}
