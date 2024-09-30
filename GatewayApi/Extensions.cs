using GatewayApi.Data;
using Microsoft.EntityFrameworkCore;


namespace GatewayApi
{
    public static class Extensions
    {
        public static IServiceCollection AddMySqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyAppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnectionString");
                options.UseSqlServer(connectionString);
            });
            return services;
        }

    }
}
