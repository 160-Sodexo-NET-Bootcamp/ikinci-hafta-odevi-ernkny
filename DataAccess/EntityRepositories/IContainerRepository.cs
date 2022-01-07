using DataAccess.GenericRepository;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityRepositories
{
    public interface IContainerRepository:IGenericRepository<Container>
    {
        Task<bool> ContainerUpdate(Container container);
    }
}
