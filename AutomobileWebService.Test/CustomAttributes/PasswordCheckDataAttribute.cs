﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutomobileWebService.Business_Logic.Models;
using Xunit.Sdk;

namespace AutomobileWebService.Test.CustomAttributes
{
    public class PasswordCheckDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new User("AdamK", "AdamK@gmail.com", "852456951", "Pass.45.word"), "Pass.45.word" };
        }
    }
}