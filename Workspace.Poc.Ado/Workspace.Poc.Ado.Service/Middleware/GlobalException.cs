using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Net;
using Workspace.Poc.Ado.Service.Exceptions;

namespace Workspace.Poc.Ado.Service.Middleware
{
    public class GlobalException :IMiddleware
    {
       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError; // 500 by default
            var message = "An unexpected error occurred.";

            if (exception is NotFound)
            {
                statusCode = HttpStatusCode.NotFound; // 404
                message = exception.Message;
            }
            else if (exception is DuplicateRecord)
            {
                statusCode = HttpStatusCode.Conflict; // 409
                message = exception.Message;
            }
            else if(exception is SqlException)
            {
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";


            return context.Response.WriteAsJsonAsync(new Error((int)statusCode, message));
        }
    }
}
