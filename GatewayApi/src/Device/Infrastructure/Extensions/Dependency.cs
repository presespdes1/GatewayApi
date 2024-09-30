using GatewayApi.src.Device.Application.Services;
using GatewayApi.src.Device.Domain.Ports;
using GatewayApi.src.Device.Infrastructure.Repositories;
using GatewayApi.src.Gateway.Domain.Ports;

namespace GatewayApi.src.Device.Infrastructure.Extensions
{
    public static class Dependency
    {
        public static IServiceCollection AddDeviceServices(this IServiceCollection services)
        {
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IDeviceService>(provider =>
            {
                var gatewayRepo = provider.GetService<IGatewayRepository>();
                var deviceRepo = provider.GetService<IDeviceRepository>();
                return new DeviceService(gatewayRepo, deviceRepo);
            });

            return services;
        }

    }
}
