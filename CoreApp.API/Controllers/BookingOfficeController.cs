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
    public class BookingOfficeController : ControllerBase
    {

        private readonly IBookingOfficeService _bookingOfficeService;

        public BookingOfficeController(IBookingOfficeService bookingOfficeService)
        {
            _bookingOfficeService = bookingOfficeService;
        }


        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> CreateBookingOffice(BookingOfficeRequestDto bookingOffice)
        {
            var _response = await _bookingOfficeService.CreateBooking(bookingOffice).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpGet("List-All")]
        public async Task<ActionResult<BookingOfficeResponseDto>> GetAllBookingOffice()
        {
            var _response = await _bookingOfficeService.GetAllBooking().ConfigureAwait(false);

            return Ok(_response);

        }


        [HttpGet("Get-ByID")]
        public async Task<ActionResult<BookingOfficeResponseDto>> GetBookingOfficeById(int Id)
        {
            var _response = await _bookingOfficeService.GetBookingById(Id);

            return Ok(_response);
        }


        [HttpPut("Update-ByID")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<BaseResponse>> UpdateBookingOffice(int Id, BookingOfficeRequestDto bookingOffice)
        {
            var _response = await _bookingOfficeService.UpdateBooking(Id, bookingOffice).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpDelete("Delete-ByID")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> DeleteBookingOffice(int Id)
        {
            var _response = await _bookingOfficeService.DeleteBooking(Id).ConfigureAwait(false);

            return Ok(_response);
        }
    }
}

