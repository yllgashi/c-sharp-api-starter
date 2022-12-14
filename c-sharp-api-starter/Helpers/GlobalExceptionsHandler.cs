using Microsoft.AspNetCore.Diagnostics;

namespace c_sharp_api_starter.Helpers
{
    public class GlobalExceptionsHandler
    {
        public static void Configure(WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    string errorMessage = context.Features.Get<IExceptionHandlerFeature>()?.Error?.Message ?? "ERRORS.GENERAL";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsJsonAsync(errorMessage);
                });
            });
        }
    }
}
