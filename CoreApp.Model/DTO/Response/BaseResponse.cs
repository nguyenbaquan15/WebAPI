using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Response
{
    public class BaseResponse
    {
        public string Result { get; set; }

        public BaseResponse()
        {
            this.Result = null;
        }
    }
}
