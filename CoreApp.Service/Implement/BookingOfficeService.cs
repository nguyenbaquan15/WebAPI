using AutoMapper;
using CoreApp.Model.DBContext;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Model.Respository;
using CoreApp.Model.UnitOfWork;
using CoreApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class BookingOfficeService : IBookingOfficeService
    {

        private readonly IGenericRespository<BookingOffice> _bookingOfficeRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingOfficeService(IGenericRespository<BookingOffice> bookingOfficeRespository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookingOfficeRespository = bookingOfficeRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse> CreateBooking(BookingOfficeRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _bookingOffice = _mapper.Map<BookingOffice>(request);

                await _bookingOfficeRespository.Create(_bookingOffice).ConfigureAwait(false);
                _unitOfWork.Commit();
                _response.Result = "SUCCESS";

            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;

        }


        public async Task<List<BookingOfficeResponseDto>> GetAllBooking()
        {
            var _response = new List<BookingOfficeResponseDto>();

            try
            {
                var _allBookingOffice = _bookingOfficeRespository.GetAll().Include(b => b.Trip).ToList();

                _response = _mapper.Map<List<BookingOfficeResponseDto>>(_allBookingOffice);
            }
            catch (Exception)
            {

            }

            return _response;
        }


        public async Task<BookingOfficeResponseDto> GetBookingById(int Id)
        {
            var _response = new BookingOfficeResponseDto();

            try
            {
                var _bookingOffice = _bookingOfficeRespository.GetId().Include(b => b.Trip).FirstOrDefault(b => b.BookingOfficeId == Id);

                if (_bookingOffice != null)
                {
                    _response = _mapper.Map<BookingOfficeResponseDto>(_bookingOffice);
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


        public async Task<BaseResponse> UpdateBooking(int Id, BookingOfficeRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _bookingOffice = await _bookingOfficeRespository.FindId(Id);

                var _item = _mapper.Map<BookingOffice>(request);

                if (_bookingOffice != null)
                {
                    _bookingOffice.Name = _item.Name;
                    _bookingOffice.PhoneNumber = _item.PhoneNumber;
                    _bookingOffice.Price = _item.Price;
                    _bookingOffice.Place = _item.Place;
                    _bookingOffice.Deadline = _item.Deadline;
                    _bookingOffice.TripId = _item.TripId;

                    await _bookingOfficeRespository.Update(_bookingOffice).ConfigureAwait(false);

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


        public async Task<BaseResponse> DeleteBooking(int Id)
        {
            var _response = new BaseResponse();

            try
            {
                var _bookingOffice = await _bookingOfficeRespository.FindId(Id);

                if (_bookingOffice != null)
                {
                    await _bookingOfficeRespository.Delete(_bookingOffice).ConfigureAwait(false);
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
