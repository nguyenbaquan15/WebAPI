using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Response
{
    public class LoginResponseDto : BaseResponse
    {
        public string Token { get; set; }
    }
}
