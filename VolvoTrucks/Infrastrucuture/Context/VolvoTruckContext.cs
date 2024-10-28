using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using SQLitePCL;

namespace Infrastrucuture.Context
{
    public class VolvoTruckContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public VolvoTruckContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
            Batteries.Init();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Truck> Trucks { get; set; }
    }
}
