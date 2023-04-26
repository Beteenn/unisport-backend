using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IoC.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, string ambiente)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Unisport API",
                    Version = "v1",
                    Description = $"Ambiente {ambiente}"
                });

                OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
                {
                    Description = "Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };

                options.AddSecurityDefinition("Bearer", securityDefinition);

                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                };

                OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
                {
                    { securityScheme, new string[] { } },
                };

                options.AddSecurityRequirement(securityRequirements);

            });

            return services;
        }
    }
}
