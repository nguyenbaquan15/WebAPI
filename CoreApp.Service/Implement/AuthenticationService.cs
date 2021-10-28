using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Model.Respository;
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

        private readonly IGenericRespository<Employee> _employeeRespository;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;


        public AuthenticationService(IGenericRespository<Employee> employeeRespository, IConfiguration configuration, IMapper mapper)
        {
            _employeeRespository = employeeRespository;
            _configuration = configuration;
            _mapper = mapper;
        }


        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {

            var _response = new LoginResponseDto();

            try
            {
                var _employeeDb = _employeeRespository.FindByCondition(
                    item => item.Account == request.Username).FirstOrDefault();

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


        private string GenerateJwtToken(Employee employee)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, employee.Fullname),
               new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()),
               new Claim(ClaimTypes.Role, employee.Department)
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

    }
}
