using Microsoft.AspNetCore.Diagnostics;
using ServicesStore.Api.Authors.ApiResult;

namespace ServicesStore.Api.Authors.Extensions
{
    public static class ExtendedMethods
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    ApiBasicResult apiResult = new ApiBasicResult(exceptionHandlerPathFeature?.Error);
                    await context.Response.WriteAsJsonAsync(apiResult);
                });
            });
        }
    }
}
