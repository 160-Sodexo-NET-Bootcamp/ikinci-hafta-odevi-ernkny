using DataAccess.Context;
using DataAccess.GenericRepository;
using DataAccess.Uow;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityRepositories
{
    public class ContainerRepository: GenericRepository<Container>, IContainerRepository
    {
        private VehicleDbContext context;
        private ILogger logger;
        public ContainerRepository(VehicleDbContext context, ILogger logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }
    
        public async Task<bool> ContainerUpdate(Container con)
        {
            var result =  context.Containers.AsNoTracking().First(x=>x.Id==con.Id);
          con.VehicleId = result.VehicleId;
            var track=context.Entry(con);
            track.State = EntityState.Modified;
            return true;
        }
    }
}
