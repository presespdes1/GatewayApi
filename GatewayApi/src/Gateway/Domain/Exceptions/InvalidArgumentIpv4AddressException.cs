namespace GatewayApi.src.Gateway.Domain.Exceptions
{
    public class InvalidArgumentIpv4AddressException: Exception
    {
        public const string INVALID_ADDRESS_MESSAGE = "IPv4 Address is invalid!";

        public InvalidArgumentIpv4AddressException(): base(INVALID_ADDRESS_MESSAGE)
        {
            
        }
    }
}
