using CoreApp.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CoreAppDbContext _dbContext;

        public UnitOfWork(CoreAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

    }
}
