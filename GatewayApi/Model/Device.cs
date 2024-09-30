using GatewayApi.src.Device.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GatewayApi.Model
{
    [Table("Devices")]
    public class Device
    {
        public Guid Id { get; set; }
        [Required]
        public string Vendor { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }

        public string GateWaySerial { get; set; }
        public Gateway Gateway { get; set; }
    }
}
