using GatewayApi.src.Gateway.Domain.Dtos;
using GatewayApi.src.Gateway.Domain.Entities;

namespace GatewayApi.src.Gateway.Domain.Ports
{
    public interface IGatewayRepository
    {
        public Task<GatewayEntity> Get(string gatewaySerial);
        public Task<List<GatewayEntity>> GetAll();
        public Task Create(GatewayEntity entity);

        public Task<GatewayEntity> Update(string gatewaySerial, GatewayUpdateDto gatewayUdapteDto);

        public Task Delete(string gatewaySerial);

        public Task<bool> Exists(string gatewaySerial);
    }
}
