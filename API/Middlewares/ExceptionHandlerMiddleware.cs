using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Exception;
using System.Net;
using API.Constants;

namespace API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);   
            }
            catch (System.Exception ex)
            {                
                await HandleExceptionAsync(context, ex); 
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unexpected error ocurred");

            ExceptionResponse response = exception switch 
            {
                ApplicationException => new ExceptionResponse(HttpStatusCode.BadRequest, ExceptionConstants.ApplicationException),
                KeyNotFoundException => new ExceptionResponse(HttpStatusCode.NotFound, ExceptionConstants.KeyNotFoundException),
                UnauthorizedAccessException => new ExceptionResponse(HttpStatusCode.Unauthorized, ExceptionConstants.UnauthorizedAccessException),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, ExceptionConstants.DefaultException) 
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }

    }
}