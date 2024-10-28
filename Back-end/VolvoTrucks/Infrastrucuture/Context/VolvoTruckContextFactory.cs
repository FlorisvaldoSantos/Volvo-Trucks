using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Context
{
    public class VolvoTruckContextFactory : IDesignTimeDbContextFactory<VolvoTruckContext>
    {
        private readonly IConfiguration _configuration;

        public VolvoTruckContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public VolvoTruckContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VolvoTruckContext>();
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            return new VolvoTruckContext(_configuration, optionsBuilder.Options);
        }
    }
}
