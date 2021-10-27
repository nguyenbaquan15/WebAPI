using CoreApp.Model.DBContext;
using CoreApp.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.Respository
{
    public class GenericRespository<TEntity> : IGenericRespository<TEntity> where TEntity : class
    {

        private readonly CoreAppDbContext _dbContext;

        public GenericRespository(CoreAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            //Add data to SQl Server
            await _dbContext.Set<TEntity>().AddAsync(entity);
            
        }

        public IQueryable<TEntity> GetAll()
        {
            //Get all of data from SQl Server
            return _dbContext.Set<TEntity>().AsNoTracking();          

        }

        public async Task<TEntity> FindId(int Id)
        {
            //Get data by Id from SQl Server
            return await _dbContext.Set<TEntity>().FindAsync(Id);
        }

        public IQueryable<TEntity> GetId()
        {
            //Find data by Id from SQl Server
            return _dbContext.Set<TEntity>().AsNoTracking();

        }

        public async Task Update(TEntity entity)
        {
            // Update data to SQl Server
            _dbContext.Set<TEntity>().Update(entity);
            
        }

        public async Task Delete(TEntity entity)
        {
            // Delete data to SQl Server
            _dbContext.Set<TEntity>().Remove(entity);
            
        }

    }
}
