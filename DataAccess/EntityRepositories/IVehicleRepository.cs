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
    public interface IVehicleRepository:IGenericRepository<Vehicle>
    {
         List<VehCon> GetVehicleWithCons(long id);
         Task<bool> DeleteVehicleWithCons(long id);
    }
}
