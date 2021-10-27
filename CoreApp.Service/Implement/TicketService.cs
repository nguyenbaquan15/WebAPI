using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Model.Respository;
using CoreApp.Model.UnitOfWork;
using CoreApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class TicketService : ITicketService
    {

        private readonly IGenericRespository<Ticket> _ticketRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IGenericRespository<Ticket> ticketRespository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ticketRespository = ticketRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse> CreateTicket(TicketRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _ticket = _mapper.Map<Ticket>(request);

                await _ticketRespository.Create(_ticket).ConfigureAwait(false);
                _unitOfWork.Commit();
                _response.Result = "SUCCESS";
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;

        }


        public async Task<List<TicketResponseDto>> GetAllTicket()
        {
            var _response = new List<TicketResponseDto>();

            try
            {
                var _allTicket = _ticketRespository.GetAll().Include(b => b.Trip).ToList();

                _response = _mapper.Map<List<TicketResponseDto>>(_allTicket);
            }
            catch (Exception)
            {

            }

            return _response;
        }


        public async Task<TicketResponseDto> GetTicketById(int Id)
        {
            var _response = new TicketResponseDto();

            try
            {
                var _ticket = _ticketRespository.GetId().Include(b => b.Trip).FirstOrDefault(b => b.TicketId == Id);

                if (_ticket != null)
                {
                    _response = _mapper.Map<TicketResponseDto>(_ticket);
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


        public async Task<BaseResponse> UpdateTicket(int Id, TicketRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _ticket = await _ticketRespository.FindId(Id);

                var _item = _mapper.Map<Ticket>(request);

                if (_ticket != null)
                {
                    _ticket.Customer = _item.Customer;
                    _ticket.BookingTime = _item.BookingTime;
                    _ticket.TripId = _item.TripId;
                    _ticket.LicensePlate = _item.LicensePlate;

                    await _ticketRespository.Update(_ticket).ConfigureAwait(false);

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


        public async Task<BaseResponse> DeleteTicket(int Id)
        {
            var _response = new BaseResponse();

            try
            {
                var _ticket = await _ticketRespository.FindId(Id);

                if (_ticket != null)
                {
                    await _ticketRespository.Delete(_ticket).ConfigureAwait(false);

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
