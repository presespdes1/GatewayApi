using GatewayApi.src.Device.Domain.Dtos;
using GatewayApi.src.Device.Domain.Entities;

namespace GatewayApi.src.Device.Domain.Ports
{
    public interface IDeviceRepository
    {
        public Task Delete(Guid Id);
        public Task Create(DeviceCreateDto createDto);
        public Task<bool> Exists(Guid Id);
    }
}
