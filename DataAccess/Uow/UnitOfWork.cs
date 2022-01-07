using DataAccess.Context;
using DataAccess.EntityRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Uow
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly VehicleDbContext context;

        public IVehicleRepository Vehicle { get; private set; }
        public IContainerRepository Container { get; private set; }

    
        public UnitOfWork(VehicleDbContext context, ILoggerFactory loggerFactory,IConfiguration configuration)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("patika");

            Container = new ContainerRepository(context, logger);
            Vehicle = new VehicleRepository(context, logger);
            
           
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
