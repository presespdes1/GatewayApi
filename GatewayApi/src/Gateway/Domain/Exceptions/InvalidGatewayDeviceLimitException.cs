namespace GatewayApi.src.Gateway.Domain.Exceptions
{
    public class InvalidGatewayDeviceLimitException: Exception
    {
        private const string INVALID_GATEWAY_DEVICE_LIMIT_MESSAGE = "This Gateway has reached the limit of devices allowed.";
        public InvalidGatewayDeviceLimitException(): base(INVALID_GATEWAY_DEVICE_LIMIT_MESSAGE)
        {
            
        }
    }
}
