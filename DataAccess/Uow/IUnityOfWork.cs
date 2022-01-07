using DataAccess.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Uow
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle{get; }
        IContainerRepository Container { get; }

        int Complete();
    }
}
