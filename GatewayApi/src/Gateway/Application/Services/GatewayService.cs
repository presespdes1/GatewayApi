using GatewayApi.src.Gateway.Domain.Dtos;
using GatewayApi.src.Gateway.Domain.Entities;
using GatewayApi.src.Gateway.Domain.Exceptions;
using GatewayApi.src.Gateway.Domain.Ports;
using GatewayApi.src.Gateway.Infrastructure.Extensions;

namespace GatewayApi.src.Gateway.Application.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IGatewayRepository _gatewayRepo;
        public GatewayService(IGatewayRepository gatewayRepo)
        {
            _gatewayRepo = gatewayRepo;
        }
        public async Task CreateGatewayAsync(GatewayCreateDto gatewayCreateDto)
        {
            if (await _gatewayRepo.Exists(gatewayCreateDto.Serial))
            {
                throw new InvalidArgumentGatewayCreateException();
            }
            await _gatewayRepo.Create(gatewayCreateDto.ToEntity());
        }

        public async Task DeleteGatewayAsync(string serial)
        {
            if (!(string.IsNullOrEmpty(serial) || await _gatewayRepo.Exists(serial)))
            {
                throw new InvalidNotFoundGatewayException();
            }
            await _gatewayRepo.Delete(serial);
        }

        public async Task<List<GatewayEntity>> GetAllGatewaysAsync()
        {
            var listGatewaysEntities = await _gatewayRepo.GetAll();

            return listGatewaysEntities;
        }

        public async Task<GatewayEntity> GetGatewayAsync(string serial)
        {
            if (!(string.IsNullOrEmpty(serial) || await _gatewayRepo.Exists(serial)))
            {
                throw new InvalidNotFoundGatewayException();
            }
            var gatewayEntity = await _gatewayRepo.Get(serial);

            return gatewayEntity;
        }

        public async Task<GatewayEntity> UpdateGatewayAsync(string gatewaySerial, GatewayUpdateDto updateDto)
        {
            if (!(string.IsNullOrEmpty(gatewaySerial) || await _gatewayRepo.Exists(gatewaySerial)))
            {
                throw new InvalidNotFoundGatewayException();
            }
            var entity = await _gatewayRepo.Update(gatewaySerial, updateDto);

            return entity;
        }
    }
}
