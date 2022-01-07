using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    interface IVehicleDbContext
    {
        DbSet<Vehicle> Vehicles { get; set; }

        int SaveChanges();
    }
}
