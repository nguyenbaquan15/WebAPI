using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interface
{
    public interface IEmployeeService
    {
        public Task<BaseResponse> CreateEmployee(EmployeeRequestDto request);
        public Task<List<EmployeeResponseDto>> GetAllEmployee();
        public Task<EmployeeResponseDto> GetEmployeeById(int Id);
        public Task<BaseResponse> UpdateEmployee(int Id, EmployeeRequestDto request);
        public Task<BaseResponse> DeleteEmployee(int Id);


    }
}
