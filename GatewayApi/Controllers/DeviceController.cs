using GatewayApi.src.Device.Domain.Dtos;
using GatewayApi.src.Device.Domain.Exceptions;
using GatewayApi.src.Device.Domain.Ports;
using GatewayApi.src.Gateway.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GatewayApi.Controllers
{
    [ApiController]
    [Route("device")]
    public class DeviceController: ControllerBase
    {
        private readonly IDeviceService _service;
        public DeviceController(IDeviceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeviceCreateDto createdto)
        {
            try
            {
                if(!ModelState.IsValid) { return BadRequest(ModelState); }
                await _service.CreateDeviceAsync(createdto);
                return Ok();
            }
            catch (Exception ex) when (ex is InvalidNotFoundGatewayException ||
                                       ex is InvalidGatewayDeviceLimitException)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await _service.DeleteDeviceAsync(Id);

                return NoContent();
            }
            catch (InvalidNotFoundDeviceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
