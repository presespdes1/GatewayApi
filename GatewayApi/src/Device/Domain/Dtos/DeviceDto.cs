using GatewayApi.src.Device.Domain.Enum;

namespace GatewayApi.src.Device.Domain.Dtos
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string? Vendor { get; set; }
        public DateTime CreateAt { get; set; }
        public Status Status { get; set; }
    }
}
