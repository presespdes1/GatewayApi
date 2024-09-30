using GatewayApi.src.Gateway.Domain.Dtos;
using GatewayApi.src.Gateway.Domain.Exceptions;
using GatewayApi.src.Gateway.Domain.Ports;
using GatewayApi.src.Gateway.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GatewayApi.Controllers
{
    [ApiController]
    [Route("gateway")]
    public class GatewayController: ControllerBase
    {
        private readonly IGatewayService _gateway;
        public GatewayController(IGatewayService gateway)
        {
            _gateway = gateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listGatewaysEntities = await _gateway.GetAllGatewaysAsync();

                return Ok(listGatewaysEntities.Select(e => e.ToDto()));
            }
             catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(GatewayCreateDto createDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); } 
            try
            {
                await _gateway.CreateGatewayAsync(createDto);

                return CreatedAtAction(nameof(GetBySerial), new { serial = createDto.Serial}, createDto);
            }
            catch (Exception ex) when (ex is InvalidArgumentIpv4AddressException ||
                                       ex is InvalidArgumentGatewayCreateException)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{serial}")]
        public async Task<IActionResult> Delete(string serial)
        {
            try
            {
                await _gateway.DeleteGatewayAsync(serial);
                return NoContent();
            }
            catch (InvalidNotFoundGatewayException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{serial}")]
        public async Task<IActionResult> GetBySerial(string serial)
        {
            try
            {
                var entity = await _gateway.GetGatewayAsync(serial);

                return Ok(entity.ToDto());
            }
            catch (InvalidNotFoundGatewayException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{serial}")]
        public async Task<IActionResult> Update(string serial, GatewayUpdateDto updateDto)
        {
            try
            {
                var entity = await _gateway.UpdateGatewayAsync(serial, updateDto);

                return Ok(entity.ToDto());
            }
            catch (InvalidNotFoundGatewayException ex)
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
