using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private  readonly ILogger _logger;
        private VehicleDbContext context;
        internal DbSet<T> dbset;
        public GenericRepository(VehicleDbContext _context,ILogger logger)
        {
            this._logger = logger;
            this.context = _context;

            dbset = context.Set<T>();
            
            
        }
        public async Task<bool> Add(T entity)
        {
             dbset.Add(entity);
             
               return true;
            
        }

        public async Task<bool> Delete(long id)
        {
            
            var result=dbset.Find(id);
            
            dbset.Remove(result);
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            
            return await dbset.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var result = await dbset.FindAsync(id);
            
            return result;
        }

        public async Task<bool> Update(T entity)
        {
            dbset.Update(entity);
            return true;
        }
    }
}
