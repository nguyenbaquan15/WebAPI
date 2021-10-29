using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> CreateEmployee(EmployeeRequestDto employee)
        {
            var _response = await _employeeService.CreateEmployee(employee).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpGet("Get-All")]
        public async Task<ActionResult<EmployeeResponseDto>> GetAllEmployee()
        {
            var _response = await _employeeService.GetAllEmployee().ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpGet("Get-ByID")]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmpoyeeById(int Id)
        {
            var _response = await _employeeService.GetEmployeeById(Id);

            return Ok(_response);

        }

        [HttpPut("Update-ByID")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> UpdateEmployee(int Id, EmployeeRequestDto employee)
        {
            var _response = await _employeeService.UpdateEmployee(Id, employee).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpDelete("Delete-ByID")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> DeleteEmployee(int Id)
        {
            var _response = await _employeeService.DeleteEmployee(Id).ConfigureAwait(false);

            return Ok(_response);
        }
    }
}
