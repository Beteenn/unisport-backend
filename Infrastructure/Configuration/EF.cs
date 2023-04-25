using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class EF
	{
        public static IServiceCollection InitializeEFConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<Context>(options =>
                {
                    options.UseSqlServer(connectionString);
                }
            );

            return services;
        }
    }
}
