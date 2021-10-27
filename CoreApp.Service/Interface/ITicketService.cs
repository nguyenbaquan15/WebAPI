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
    public interface ITicketService
    {
        public Task<BaseResponse> CreateTicket(TicketRequestDto request);
        public Task<List<TicketResponseDto>> GetAllTicket();
        public Task<TicketResponseDto> GetTicketById(int Id);
        public Task<BaseResponse> UpdateTicket(int Id, TicketRequestDto request);
        public Task<BaseResponse> DeleteTicket(int Id);
    }
}
