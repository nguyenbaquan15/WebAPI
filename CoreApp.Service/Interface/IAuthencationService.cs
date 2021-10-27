using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interface
{
    public interface IAuthencationService
    {
        string Authenticate(string username, string password);
    }
}
