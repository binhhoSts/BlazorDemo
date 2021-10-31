using BlazorServer.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorServer.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var responseData = new ExceptionResponse
                {
                    data = null,
                    message = ex.Message,
                    errorDetails = null,
                };

                // ignore these
                if (ex is OperationCanceledException || ex is ObjectDisposedException)
                {
                    return;
                }

                if (ex is UnauthorizedException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    responseData.statusCode = HttpStatusCode.Forbidden;
                }
                else if (ex is BadRequestException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseData.statusCode = HttpStatusCode.BadRequest;
                }
                else if (ex is NotFoundException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseData.statusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    responseData.errorDetails = ex.StackTrace;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseData.statusCode = HttpStatusCode.InternalServerError;
                }

                // serialize data to json
                var responseJson = JsonConvert.SerializeObject(responseData);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(responseJson);
            }
        }
    }
}
