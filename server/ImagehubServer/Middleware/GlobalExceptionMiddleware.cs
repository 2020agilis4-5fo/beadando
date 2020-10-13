using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Imagehub.Core.Middleware
{
    /// <summary>
    /// An extension method configuring a global exception handler.
    /// </summary>
    public static class GlobalExceptionMiddleware
    {
        // based on: https://code-maze.com/global-error-handling-aspnetcore/
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(err =>
            {
                err.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    
                    // todo: log specific error in the feature
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(new
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message // todo: map app errors to clienterrors
                            }));
                    }
                });
            });
        }
    }
}
