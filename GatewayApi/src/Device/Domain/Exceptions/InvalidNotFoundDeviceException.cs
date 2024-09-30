namespace GatewayApi.src.Device.Domain.Exceptions
{
    public class InvalidNotFoundDeviceException: Exception
    {
        private const string INVALID_NOT_FOUND_MESSAGE = "This device does not exist.";

        public InvalidNotFoundDeviceException() : base(INVALID_NOT_FOUND_MESSAGE)
        {

        }
    }
}
