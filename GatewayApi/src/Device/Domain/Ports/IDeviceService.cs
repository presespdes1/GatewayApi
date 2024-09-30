using GatewayApi.src.Device.Domain.Dtos;

namespace GatewayApi.src.Device.Domain.Ports
{
    public interface IDeviceService
    {
        public Task CreateDeviceAsync(DeviceCreateDto createDto);
        public Task DeleteDeviceAsync(Guid Id);        
    }
}
