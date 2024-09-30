using GatewayApi.src.Gateway.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace GatewayApi.src.Gateway.Domain.Dtos
{
    public abstract class GatewayBaseDto
    {
        [Required]
        public string Name { get; }
        [Required]
        public string Address { get; }

        public GatewayBaseDto(string name, string address)
        {
            Name = name;
            Address = address;
        }


    }
}
