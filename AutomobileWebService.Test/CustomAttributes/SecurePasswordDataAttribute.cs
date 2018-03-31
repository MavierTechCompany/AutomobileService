using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    public class SecurePasswordDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Pass.12.word", "andre.kowalsky@gmail.com", new DateTime(2017, 11, 2) };
        }
    }
}