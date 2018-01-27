using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AutomobileWebService.Tests.CustomAttributes
{
    public class PasswordCheckDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new User(Guid.NewGuid(), "AdamK", "AdamK@gmail.com", "852456951", "Pass.45.word"), "Pass.45.word" };
        }
    }
}
