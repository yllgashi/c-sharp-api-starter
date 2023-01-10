using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using models;
using repository.Products;
using services.Products;
using System.Text;

namespace c_sharp_api_starter.Helpers
{
    internal class GlobalServices
    {
        internal static void AddDefaultServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
        }

        internal static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "C Sharp Api Starter", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }

        internal static void UseDevelopmentMiddlewares(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        internal static void UseMiddlewares(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }

        internal static void AddTransientDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProductsService, ProductsService>();
            builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
        }

        internal static void InitializeAppSettings(WebApplicationBuilder builder)
        {
            AppSettings.ConnectionString = builder.Configuration.GetSection(AppSettings.CONNECTION_STRINGS_SECTION_KEY)[AppSettings.MSSQL_KEY] ?? "";
            AppSettings.AuthorizationSecretKey = builder.Configuration.GetSection(AppSettings.AUTHORIZATION_SECTION)[AppSettings.AUTHORIZATION_SECRET_KEY] ?? "";
            AppSettings.AuthorizationIssuer = builder.Configuration.GetSection(AppSettings.AUTHORIZATION_SECTION)[AppSettings.AUTHORIZATION_JWT_ISSUER_KEY] ?? "";
            AppSettings.AuthorizationAudience = builder.Configuration.GetSection(AppSettings.AUTHORIZATION_SECTION)[AppSettings.AUTHORIZATION_JWT_AUDIENCE_KEY] ?? "";
        }

        internal static void AddAuthorization(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = AppSettings.AuthorizationIssuer,
                        ValidAudience = AppSettings.AuthorizationAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.AuthorizationSecretKey))
                    };
                });
        }
    }
}
