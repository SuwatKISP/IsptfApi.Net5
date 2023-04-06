using ISPTF.Models.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ISPTF.API.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature !=null)
                    {
                        // in production version write exception to the database include stack trace
                        await context.Response.WriteAsync(new ApiException()
                        {
                            StatusCode=context.Response.StatusCode,
                            //Message=contextFeature.Error.Message
                            Message="Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
