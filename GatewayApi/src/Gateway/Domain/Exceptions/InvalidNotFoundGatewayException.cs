namespace GatewayApi.src.Gateway.Domain.Exceptions
{
    public class InvalidNotFoundGatewayException: Exception
    {
        private const string INVALID_NOT_FOUND_MESSAGE = "This gateway does not exist.";

        public InvalidNotFoundGatewayException(): base(INVALID_NOT_FOUND_MESSAGE)
        {
            
        }
    }
}
