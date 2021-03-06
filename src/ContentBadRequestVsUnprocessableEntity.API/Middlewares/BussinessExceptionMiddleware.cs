using System.Net;
using System.Threading.Tasks;

using ContentBadRequestVsUnprocessableEntity.Services.Abstractions;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace ContentBadRequestVsUnprocessableEntity.API.Middlewares
{
    public class BussinessExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public BussinessExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BussinessException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                context.Response.ContentType = "application/json";
                var response = new UnprocessableEntityResponse(exception.ErrorCode, exception.Description);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
