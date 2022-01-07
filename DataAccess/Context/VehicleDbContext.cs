using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class VehicleDbContext : DbContext,IVehicleDbContext
    {
        
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
            
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Container> Containers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        
    }
}
