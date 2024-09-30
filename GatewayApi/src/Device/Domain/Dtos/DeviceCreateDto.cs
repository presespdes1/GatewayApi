using System.ComponentModel.DataAnnotations;

namespace GatewayApi.src.Device.Domain.Dtos
{
    public class DeviceCreateDto
    {
        [Required]
        public string Vendor { get; set; } = "";
        [Required]
        public string GatewaySerial { get; set; } = "";
    }
}
