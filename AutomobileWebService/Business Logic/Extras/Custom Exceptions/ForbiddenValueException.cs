using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Extras.Custom_Exceptions
{
    public class ForbiddenValueException : Exception
    {
        public ForbiddenValueException()
        {

        }

        public ForbiddenValueException(string message) : base(message)
        {

        }

        public ForbiddenValueException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
