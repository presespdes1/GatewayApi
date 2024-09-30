using GatewayApi.src.Device.Domain.Dtos;

namespace GatewayApi.src.Device.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static Model.Device ToModel(this DeviceCreateDto dto)
        {
            return new Model.Device
            {
                Vendor = dto.Vendor,
                GateWaySerial = dto.GatewaySerial
            };
        }
    }
}
