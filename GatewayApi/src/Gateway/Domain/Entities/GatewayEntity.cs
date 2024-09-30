using GatewayApi.src.Device.Domain.Entities;
using GatewayApi.src.Gateway.Domain.Exceptions;

namespace GatewayApi.src.Gateway.Domain.Entities
{
    public class GatewayEntity
    {
        public string Serial { get; set; } = "";
        public string Name { get; set; } = "";

        private string _address;
        public string Address
        {
            get { return _address; }
            set 
            {
                if(AddressValidator(value))
                    _address = value;
                else
                    throw new InvalidArgumentIpv4AddressException();
            }
        }
        public List<DeviceEntity> Devices { get; set; } = new List<DeviceEntity>();

        

        private bool AddressValidator(string value)
        {
            var ipv4Address = value.Split('.');
            var lengthAddress = ipv4Address.Length;

            if (lengthAddress != 4)
                return false;

            foreach (var address in ipv4Address)
            {
                var spaces = address.Contains(" ");
                int number;
                var isNumber = int.TryParse(address, out number);
                var range = number >= 0 && number <= 255;
                if (!(isNumber && range) || spaces)
                    return false;

            }
            return true;
        }
    }
}
