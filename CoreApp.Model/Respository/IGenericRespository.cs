using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.Respository
{
    public interface IGenericRespository<TEntity>
    {
        //Add data to SQl Server
        public Task Create(TEntity entity);

        //Get all of data from SQl Server
        public IQueryable<TEntity> GetAll();

        //Get data by Id from SQl Server
        public IQueryable<TEntity> GetId();

        // Find by Id
        public Task<TEntity> FindId(int Id);

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        // Update data to SQl Server
        public Task Update(TEntity entity);

        // Delete data to SQl Server
        public Task Delete(TEntity entity);
    }
}
