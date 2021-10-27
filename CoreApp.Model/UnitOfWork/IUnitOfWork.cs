using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.UnitOfWork
{
    public interface IUnitOfWork
    {
        public void Commit();
    }
}
