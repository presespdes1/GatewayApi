using GatewayApi.Data;
using GatewayApi.src.Device.Domain.Dtos;
using GatewayApi.src.Device.Domain.Ports;
using GatewayApi.src.Device.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GatewayApi.src.Device.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly MyAppDbContext _context;
        public DeviceRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task Create(DeviceCreateDto createDto)
        {
            var deviceModel = createDto.ToModel();
            await _context.AddAsync(deviceModel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid Id)
        {
            var deviceModel = await _context.Devices.FindAsync(Id);
            _context.Devices.Remove(deviceModel);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid Id)
        {
            return await _context.Devices.AnyAsync(d => d.Id == Id);
        }
    }
}
