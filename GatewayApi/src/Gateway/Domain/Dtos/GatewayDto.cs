using GatewayApi.src.Device.Domain.Dtos;

namespace GatewayApi.src.Gateway.Domain.Dtos
{
    public class GatewayDto
    {
        public string Serial { get; init; } = "";
        public string Name { get; init; } = "";
        public string Address { get; init; } = "";
        public List<DeviceDto> Devices { get; init; } = new List<DeviceDto>();
    }
}
