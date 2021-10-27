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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [HttpPost("Add-Ticket")]
        public async Task<ActionResult<BaseResponse>> CreateTicket(TicketRequestDto ticket)
        {
            var _response = await _ticketService.CreateTicket(ticket).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpGet("Get-Ticket-ByID")]
        public async Task<ActionResult<TicketResponseDto>> GetTicketById(int Id)
        {
            var _response = await _ticketService.GetTicketById(Id);

            return Ok(_response);
        }


        [HttpGet("List-All-Ticket")]
        public async Task<ActionResult<TicketResponseDto>> GetAllTicket()
        {
            var _response = await _ticketService.GetAllTicket().ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpPut("Update-Ticket-ByID")]
        public async Task<ActionResult<BaseResponse>> UpdateTicket(int Id, TicketRequestDto ticket)
        {
            var _response = await _ticketService.UpdateTicket(Id, ticket).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpDelete("Delete-Ticket-ByID")]
        public async Task<ActionResult<BaseResponse>> DeleteTicket(int Id)
        {
            var _response = await _ticketService.DeleteTicket(Id).ConfigureAwait(false);

            return Ok(_response);
        }
    }
}
