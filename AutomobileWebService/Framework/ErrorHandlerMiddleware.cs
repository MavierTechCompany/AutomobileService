using System;
using System.Net;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AutomobileWebService.Framework
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                
                await HandleErrorAsync(context, exception);
            }
        }

        private static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var exceptionType = exception.GetType();
            var response = "Ops.. Something went wrong.";
            var statusCode = (int)HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case Exception ex when exceptionType == typeof(ForbiddenValueException):
                    response = "One or more arguments are wrong.";
                    statusCode = 422;
                    break;

                case Exception ex when exceptionType == typeof(NullResponseException):
                    response = "There is no content with given arguments.";
                    statusCode = 404;
                    break;
            }

            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(payload);
        }
    }
}