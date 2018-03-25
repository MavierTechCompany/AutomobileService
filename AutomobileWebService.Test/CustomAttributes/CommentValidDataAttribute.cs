using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    public class CommentValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {"This is avesome!"};
        }
    }
}