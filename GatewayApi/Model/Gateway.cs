
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GatewayApi.Model
{
    [Table("Gateways")]
    public class Gateway
    {
        [Key]
        public string Serial { get; set; } = "";
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Address { get; set; } = "";
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
