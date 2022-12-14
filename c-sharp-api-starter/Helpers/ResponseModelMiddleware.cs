using System.IO;

namespace c_sharp_api_starter.Helpers
{
    public class ResponseModelMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseModelMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            int statusCode = context.Response.StatusCode;
            bool isResponseJson = IsResponseInJSON(context);
            bool isSwaggerPage = context.Request.Path.Value.Contains("swagger");

            if (!isResponseJson || isSwaggerPage) return;
            else if (statusCode >= 200 && statusCode < 300) await HandleSuccessResponse(context);
            else await HandleErrorResponse(context);


            //var modifiedResult = ResponseResult.Success(body);
            //await context.Response.WriteAsJsonAsync(modifiedResult);

        }

        private async static Task HandleSuccessResponse(HttpContext context)
        {
            try
            {
                var stream = context.Response.Body;

                var reader = new StreamReader(stream);
                string data = reader.ReadToEnd();

                // modify
                var response = ResponseResult.Success(data);
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                return;
            }

        }

        private async static Task HandleErrorResponse(HttpContext context)
        {
            string errorMessage = ""; // get from context.Response.Body
            ResponseResult result = ResponseResult.Error(errorMessage);
            await context.Response.WriteAsJsonAsync(result);
        }

        private static bool IsResponseInJSON(HttpContext context)
        {
            return context.Response.Headers.ContentType.Count(x => x.Contains("application/json")) == 0 ? false : true;
        }
    }
}
