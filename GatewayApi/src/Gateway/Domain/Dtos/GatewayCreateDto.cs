using GatewayApi.src.Gateway.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace GatewayApi.src.Gateway.Domain.Dtos
{
    public class GatewayCreateDto : GatewayBaseDto
    {
        [Required]
        public string Serial { get; init; } = "";

        public GatewayCreateDto(string name, string address) : base(name, address)
        {

        }
    }

}
