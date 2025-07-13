using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace Handson.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 1. Get the exception message
            var exception = context.Exception;
            string logMessage = $"[{DateTime.Now}] Exception: {exception.Message}{Environment.NewLine}";

            // 2. Write to a file (you can choose any path you prefer)
            File.AppendAllText("logs/exceptions.txt", logMessage); // Make sure "logs" folder exists or handle its creation

            // 3. Return a 500 error result
            context.Result = new ObjectResult("Internal Server Error. Please contact support.")
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
