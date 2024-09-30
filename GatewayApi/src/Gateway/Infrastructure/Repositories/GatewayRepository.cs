using GatewayApi.Data;
using GatewayApi.src.Gateway.Domain.Dtos;
using GatewayApi.src.Gateway.Domain.Entities;
using GatewayApi.src.Gateway.Domain.Ports;
using GatewayApi.src.Gateway.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GatewayApi.src.Gateway.Infrastructure.Repositories
{
    public class GatewayRepository : IGatewayRepository
    {
        private readonly MyAppDbContext _context;
        public GatewayRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task Create(GatewayEntity entity)
        {
            var model = new Model.Gateway
            {
                Serial = entity.Serial,
                Name = entity.Name,
                Address = entity.Address
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(string gatewaySerial)
        {
            var gatewayModel = await _context.Gateways.FindAsync(gatewaySerial);
            _context.Gateways.Remove(gatewayModel);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string gatewaySerial)
        {
            var isGatewayExist = await _context.Gateways.AnyAsync(g => g.Serial == gatewaySerial);
            
            return isGatewayExist;
        }

        public async Task<GatewayEntity> Get(string gatewaySerial)
        {
            var gatewayModel = await _context.Gateways.Include(g => g.Devices).FirstOrDefaultAsync(g => g.Serial == gatewaySerial);

            return gatewayModel.ToEntity();
        }

        public async Task<List<GatewayEntity>> GetAll()
        {
            var gateways = (await _context.Gateways.Include(g => g.Devices).ToListAsync()).Select(g => g.ToEntity());               

            return gateways.ToList();
        }

        public async Task<GatewayEntity> Update(string gatewaySerial, GatewayUpdateDto gatewayUdapteDto)
        {
            var gatewayModel = await _context.Gateways.FindAsync(gatewaySerial);

            gatewayModel.Name = gatewayUdapteDto.Name;
            gatewayModel.Address = gatewayUdapteDto.Address;

            await _context.SaveChangesAsync();

            return gatewayModel.ToEntity();
        }

       
    }
}
