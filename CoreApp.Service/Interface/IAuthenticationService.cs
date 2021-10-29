using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interface
{
    public interface IAuthenticationService
    {
        public Task<UserResponseDto> Login(UserRequestDto request);
        public Task<BaseResponse> Signup(UserRequestDto request);
    }
}
