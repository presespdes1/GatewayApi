using GatewayApi.src.Gateway.Domain.Dtos;
using GatewayApi.src.Gateway.Domain.Entities;

namespace GatewayApi.src.Gateway.Domain.Ports
{
    public interface IGatewayService
    {
        public Task CreateGatewayAsync(GatewayCreateDto gatewayCreateDto);
        public Task<List<GatewayEntity>> GetAllGatewaysAsync();
        public Task DeleteGatewayAsync(string serial);
        public Task<GatewayEntity> GetGatewayAsync(string serial);
        public Task<GatewayEntity> UpdateGatewayAsync(string gatewaySerial, GatewayUpdateDto updateDto);
    }
}
