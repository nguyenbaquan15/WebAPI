using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Model.Respository;
using CoreApp.Model.UnitOfWork;
using CoreApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreApp.Service.Implement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRespository<Employee> _employeeRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRespository<Employee> employeeRespository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRespository = employeeRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse> CreateEmployee(EmployeeRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _employee = _mapper.Map<Employee>(request);

                await _employeeRespository.Create(_employee).ConfigureAwait(false);

                _unitOfWork.Commit();
                _response.Result = "SUCCESS";
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;

        }


        public async Task<List<EmployeeResponseDto>> GetAllEmployee()
        {
            var _response = new List<EmployeeResponseDto>();

            try
            {
                var _allBookingOffice = _employeeRespository.GetAll().ToList();

                _response = _mapper.Map<List<EmployeeResponseDto>>(_allBookingOffice);
            }
            catch (Exception)
            {

            }

            return _response;

        }


        public async Task<EmployeeResponseDto> GetEmployeeById(int Id)
        {
            var _response = new EmployeeResponseDto();

            try
            {
                var _employee = _employeeRespository.GetId().FirstOrDefault(b => b.EmployeeId == Id);

                if (_employee != null)
                {
                    _response = _mapper.Map<EmployeeResponseDto>(_employee);
                    _response.Result = "SUCCESS";
                }
                else
                {
                    _response.Result = "NOT FOUND";
                }
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;
        }


        public async Task<BaseResponse> UpdateEmployee(int Id, EmployeeRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _employee = await _employeeRespository.FindId(Id);

                var _item = _mapper.Map<Employee>(request);

                if (_employee != null)
                {
                    _employee.Fullname = _item.Fullname;
                    _employee.DateOfBirth = _item.DateOfBirth;
                    _employee.Sex = _item.Sex;
                    _employee.Address = _item.Address;
                    _employee.PhoneNumber = _item.PhoneNumber;
                    _employee.Email = _item.Email;
                    _employee.Account = _item.Account;
                    _employee.Password = _item.Password;
                    _employee.Department = _item.Department;

                    await _employeeRespository.Update(_employee).ConfigureAwait(false);
                    _unitOfWork.Commit();
                    _response.Result = "SUCCESS";
                }
                else
                {
                    _response.Result = "NOT FOUND";
                }
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;
        }


        public async Task<BaseResponse> DeleteEmployee(int Id)
        {
            var _response = new BaseResponse();

            try
            {
                var _employee = await _employeeRespository.FindId(Id);

                if (_employee != null)
                {
                    await _employeeRespository.Delete(_employee).ConfigureAwait(false);

                    _unitOfWork.Commit();
                    _response.Result = "SUCCESS";
                }
                else
                {
                    _response.Result = "NOT FOUND";
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
