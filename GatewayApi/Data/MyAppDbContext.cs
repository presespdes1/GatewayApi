using GatewayApi.Model;
using GatewayApi.src.Device.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace GatewayApi.Data
{

    public class MyAppDbContext : DbContext
    {
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }
        public MyAppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Gateway)
                .WithMany(d => d.Devices)
                .HasForeignKey(d => d.GateWaySerial);

            modelBuilder.Entity<Device>()
                .Property(d => d.Status)
                .HasConversion<int>()
                .HasDefaultValue(Status.Offline);

            modelBuilder.Entity<Device>()
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Device>()
                .Property(d => d.Id)
                .HasDefaultValueSql("newid()");
        }

    }
}
