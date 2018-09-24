using GConta.Application.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GConta.WebAPI.Configuration
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            

            var errors = new List<string>();
            var ex = exception;
            while (ex != null)
            {
                errors.Add(ex.Message);
                ex = ex.InnerException;
            }
            var responseErro = new ResponseErro { errors = errors };

            await response.WriteAsync(JsonConvert.SerializeObject(responseErro));
        }
    }
}
