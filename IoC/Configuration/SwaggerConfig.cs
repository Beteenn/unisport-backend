using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

				//OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
				//{
				//	Name = "access-token",
				//	BearerFormat = "JWT",
				//	Scheme = "bearer",
				//	Description = "Token JWT",
				//	In = ParameterLocation.Header,
				//	Type = SecuritySchemeType.ApiKey,
				//};

				//options.AddSecurityDefinition("access-token", securityDefinition);

				//OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
				//{
				//	Reference = new OpenApiReference()
				//	{
				//		Id = "access-token",
				//		Type = ReferenceType.SecurityScheme
				//	},
				//	Name = "access-token",
				//	In = ParameterLocation.Header
				//};

				//OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
				//{
				//	{ securityScheme, new string[] { } },
				//};

				//options.AddSecurityRequirement(securityRequirements);

			});

			return services;
		}
	}
}
