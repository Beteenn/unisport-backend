using Application.Configuration.Identity.Interfaces;
using Application.Services;
using Application.Services.Identity;
using Application.Services.Interfaces;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Identity;
using Infrastructure.Repository;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Generics.Interfaces;
using Infrastructure.Repository.Interfaces;
using IoC.Configuration;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
	public static class ApplicationModule
	{
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new AutoMapperConfig();
            services.AddSingleton(mapperConfig.Mapper);

            //services.AddTransient<IMongoDbContext, MongoDbContext>();
            services.ConfigureSettings(configuration);
            services.ConfigurarServicosIntegracao(configuration);
            services.ConfigurarServices();
            services.ConfigurarRepositorios();
            services.ConfigurarAutenticacao();
            //services.ConfigurarEmailServices();

            return services;
        }

        private static void ConfigurarServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddScoped<IFaculdadeService, FaculdadeService>();
        }

        private static void ConfigurarRepositorios(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IGenericsRepository<>), typeof(GenericsRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFaculdadeRepository, FaculdadeRepository>();
        }

        private static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {            
        }

        private static void ConfigurarServicosIntegracao(this IServiceCollection services, IConfiguration configuration)
        {            
        }
        public static IServiceCollection ConfigureEF(this IServiceCollection services, string connectionString)
        {
            //services.InitializeEFConfiguration(connectionString);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<Context>(options =>
                {
                    options.UseSqlServer(connectionString);
                }
            );

            return services;
        }
        private static void ConfigurarAutenticacao(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
        }

        public static IServiceCollection ConfigureIdentityAuthentication(this IServiceCollection services)
        {
            services.AddIdentityConfiguration();

            return services;
        }
    }
    public class LowerCaseParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            return value == null ? null : value.ToString().ToLower();
        }
    }
}
