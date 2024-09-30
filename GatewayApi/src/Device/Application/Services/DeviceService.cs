using GatewayApi.src.Device.Domain.Dtos;
using GatewayApi.src.Device.Domain.Exceptions;
using GatewayApi.src.Device.Domain.Ports;
using GatewayApi.src.Gateway.Domain.Exceptions;
using GatewayApi.src.Gateway.Domain.Ports;

namespace GatewayApi.src.Device.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IGatewayRepository _gateway;
        private readonly IDeviceRepository _device;
        public DeviceService(IGatewayRepository gateway, IDeviceRepository device)
        {
            _gateway = gateway;
            _device = device;
        }
        public async Task CreateDeviceAsync(DeviceCreateDto createDto)
        {
            var isGatewayExist = await _gateway.Exists(createDto.GatewaySerial);
            if (!isGatewayExist)
            {
                throw new InvalidNotFoundGatewayException();
            }

            var gatewayEntity = await _gateway.Get(createDto.GatewaySerial);
            if (gatewayEntity.Devices.Count == 10)
            {
                throw new InvalidGatewayDeviceLimitException();
            }
            await _device.Create(createDto);
        }

        public async Task DeleteDeviceAsync(Guid Id)
        {
            var isDeviceExist = await _device.Exists(Id);
            if (!isDeviceExist)
            {
                throw new InvalidNotFoundDeviceException();
            }
            await _device.Delete(Id);
        }
    }
}
