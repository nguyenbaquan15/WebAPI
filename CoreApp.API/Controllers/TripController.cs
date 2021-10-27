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
    public class TripController : ControllerBase
    {

        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }


        [HttpPost("Add-Trip")]
        public async Task<ActionResult<BaseResponse>> CreateTrip(TripRequestDto trip)
        {
            var _response = await _tripService.CreateTrip(trip).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpGet("List-All-Trip")]
        public async Task<ActionResult<TripResponseDto>> GetAllTrip()
        {
            var _response = await _tripService.GetAllTrip().ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpGet("Get-Trip-ByID")]
        public async Task<ActionResult<TripResponseDto>> GetTripById(int Id)
        {
            var _response = await _tripService.GetTripById(Id);

            return Ok(_response);
        }


        [HttpPut("Update-Trip-ByID")]
        public async Task<ActionResult<BaseResponse>> UpdateTrip(int Id, TripRequestDto trip)
        {
            var _response = await _tripService.UpdateTrip(Id, trip).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpDelete("Delete-Trip-ByID")]
        public async Task<ActionResult<BaseResponse>> DeleteTrip(int Id)
        {
            var _response = await _tripService.DeleteTrip(Id).ConfigureAwait(false);

            return Ok(_response);
        }
    }
}
