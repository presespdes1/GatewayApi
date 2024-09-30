using GatewayApi.Data;
using GatewayApi.src.Gateway.Application.Services;
using GatewayApi.src.Gateway.Domain.Ports;
using GatewayApi.src.Gateway.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayApi.src.Gateway.Infrastructure.Extensions
{
    public static class Dependency
    {
        public static IServiceCollection AddGatewayServices(this IServiceCollection services)
        {
            services.AddScoped<IGatewayRepository, GatewayRepository>();

            services.AddScoped<IGatewayService>(serviceProvider => 
            {
                var gatewayRepo = serviceProvider.GetService<IGatewayRepository>();
                return new GatewayService(gatewayRepo);
            });

            return services;
        }
    }
}
