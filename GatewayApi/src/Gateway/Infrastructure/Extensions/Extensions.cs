using GatewayApi.Model;
using GatewayApi.src.Device.Domain.Dtos;
using GatewayApi.src.Device.Domain.Entities;
using GatewayApi.src.Gateway.Domain.Dtos;
using GatewayApi.src.Gateway.Domain.Entities;

namespace GatewayApi.src.Gateway.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static Model.Gateway ToModel(this GatewayCreateDto dto)
        {
            return new Model.Gateway
            {
                Serial = dto.Serial,
                Name = dto.Name,
                Address = dto.Address
            };
        }

        public static GatewayEntity ToEntity(this Model.Gateway model)
        {
            return new GatewayEntity
            {
                Serial = model.Serial,
                Name = model.Name,
                Address = model.Address,
                Devices = model.Devices.Select(d => new DeviceEntity 
                {
                    Id = d.Id,
                    Vendor = d.Vendor,
                    CreateAt = d.CreatedAt,
                    Status = d.Status

                }).ToList()
            };
        }

        public static GatewayEntity ToEntity(this GatewayCreateDto dto)
        {
            return new GatewayEntity
            {
                Serial = dto.Serial,
                Name = dto.Name,
                Address = dto.Address
            };
        }

        public static GatewayDto ToDto(this GatewayEntity entity)
        {
            return new GatewayDto
            {
                Serial = entity.Serial,
                Name = entity.Name,
                Address = entity.Address,
                Devices = entity.Devices.Select(d => new DeviceDto 
                { 
                    Id = d.Id,
                    Vendor = d.Vendor,
                    Status = d.Status,
                    CreateAt = d.CreateAt
                }).ToList()
            };
        }
    }
}
