using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    public class CommentNotValidData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {null};
            yield return new object[] {""};
            yield return new object[] {" "};
        }
    }
}