using c_sharp_api_starter.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
GlobalServices.AddDefaultServices(builder);

// Add swagger
GlobalServices.AddSwagger(builder);

// Build application
var app = builder.Build();

// use general exceptions handler (use error-response-model)
GlobalExceptionsHandler.Configure(app);

// use success response handler (use success-response-model)
//app.UseMiddleware<ResponseModelMiddleware>();

// Use development middlewares
if (app.Environment.IsDevelopment())
    GlobalServices.UseDevelopmentMiddlewares(app);

// use all middlewares
GlobalServices.UseMiddlewares(app);

// run application
app.Run();