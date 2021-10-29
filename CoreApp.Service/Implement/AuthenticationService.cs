using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Model.Respository;
using CoreApp.Model.UnitOfWork;
using CoreApp.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IGenericRespository<User> _userRespository;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IGenericRespository<User> userRespository, IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRespository = userRespository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<UserResponseDto> Login(UserRequestDto request)
        {

            var _response = new UserResponseDto();

            try
            {
                var _employeeDb = _userRespository.FindByCondition(
                    item => item.Username == request.Username).FirstOrDefault();

                if (_employeeDb != null)
                {

                    if (_employeeDb.Password != request.Password)
                    {
                        _response.Result = "PASSWORD WRONG";
                    }
                    else
                    {
                        _response.Token = GenerateJwtToken(_employeeDb);
                        _response.Result = "SUCCESS";
                    }
                }
                else
                {
                    _response.Result = "ACCOUNT NO EXIST";
                }

            }
            catch (Exception e)
            {
                return _response;
            }

            return _response;

        }


        private string GenerateJwtToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.Username),
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenKey = _configuration["TokenKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddHours(2);

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return tokenHandler.WriteToken(token);
        }


        public async Task<BaseResponse> Signup(UserRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _item = _mapper.Map<User>(request);

                var _user = _userRespository.FindByCondition(b => b.Username == _item.Username).FirstOrDefault();
  
                if (_user != null)
                {
                    _response.Result = _response.Result = "ACCOUNT EXIST";
                }
                else
                {
                    await _userRespository.Create(_item).ConfigureAwait(false);
                    _unitOfWork.Commit();
                    _response.Result = "SUCCESS";
                }
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;

        }

    }
}
