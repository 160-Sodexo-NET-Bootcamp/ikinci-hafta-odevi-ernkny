using DataAccess.Context;
using DataAccess.GenericRepository;
using Entity.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityRepositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private VehicleDbContext context;
        public VehicleRepository(VehicleDbContext context, ILogger logger) : base(context,logger)
        {
            this.context = context;
        }
        
        public List<VehCon>  GetVehicleWithCons(long id)
        {
            var result = from b in context.Vehicles
                         join d in context.Containers
                         on b.Id equals d.VehicleId
                         select new VehCon
                         {
                          VehicleId=b.Id ,
                          VehicleName=b.VehicleName,
                          ContainerName=d.ContainerName,
                          Latitude=d.Latitude,
                          Longitude=d.Longitude
                         };
            return result.Where(x => x.VehicleId == id).ToList();
        }
        public async Task<bool> DeleteVehicleWithCons(long id)
        {
            var entityVehicle = context.Vehicles.Find(id);
            context.Vehicles.Remove(entityVehicle);
            var entityContainer = context.Containers.Where(x => x.VehicleId == id);
            context.Containers.RemoveRange(entityContainer);

            return true;

        }


    }
}
