using System;

namespace AutomobileWebService.Business_Logic.Extras.Custom_Exceptions
{
    public class NullResponseException : Exception
    {
        public NullResponseException() { }

        public NullResponseException(string message) : base(message) { }

        public NullResponseException(string message, Exception inner) : base(message, inner) { } 
    }
}
