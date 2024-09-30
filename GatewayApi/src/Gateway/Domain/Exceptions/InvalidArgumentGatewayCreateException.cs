namespace GatewayApi.src.Gateway.Domain.Exceptions
{
    public class InvalidArgumentGatewayCreateException : Exception
    {
        private const string INVALID_GATEWAY_CREATION_MESSAGE = "This gateway already exist.";

        public InvalidArgumentGatewayCreateException(): base(INVALID_GATEWAY_CREATION_MESSAGE)
        {
            
        }
    }
}
