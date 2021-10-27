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

    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpPost("Add-Car")]
        public async Task<ActionResult<BaseResponse>> CreateCar(CarRequestDto car)
        {
            var _respone = await _carService.CreateCar(car).ConfigureAwait(false);

            return Ok(_respone);

        }


        [HttpGet("List-All-Car")]
        public async Task<ActionResult<List<CarResponseDto>>> GetAllCar()
        {
            var _respone = await _carService.GetAllCar().ConfigureAwait(false);

            return Ok(_respone);

        }


        [HttpGet("Get-Car-ByID")]
        public async Task<ActionResult<CarResponseDto>> GetCarById(int Id)
        {
            var _respone = await _carService.GetCarById(Id);

            return Ok(_respone);

        }


        [HttpPut("Update-Car-ByID")]
        public async Task<ActionResult<BaseResponse>> UpdateCar(int Id, CarRequestDto car)
        {
            var _respone = await _carService.UpdateCar(Id, car).ConfigureAwait(false);

            return Ok(_respone);
        }


        [HttpDelete("Delete-Car-ByID")]
        public async Task<ActionResult<BaseResponse>> DeleteCar(int Id)
        {
            var _respone = await _carService.DeleteCar(Id).ConfigureAwait(false);

            return Ok(_respone);
        }
    }
}
