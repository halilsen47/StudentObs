using Entity.ErrorModel;
using Entity.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Service.Services.Abstractions;
namespace web.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
            ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    //Hata olup olmadığının kontrolü null ise hata yok 
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    
                    if(contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            NullException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError,

                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    } 

                });
            });
        }
    }
}
