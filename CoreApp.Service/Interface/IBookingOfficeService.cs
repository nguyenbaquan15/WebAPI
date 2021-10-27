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
    public interface IBookingOfficeService
    {
        public Task<BaseResponse> CreateBooking(BookingOfficeRequestDto request);
        public Task<List<BookingOfficeResponseDto>> GetAllBooking();
        public Task<BookingOfficeResponseDto> GetBookingById(int Id);
        public Task<BaseResponse> UpdateBooking(int Id, BookingOfficeRequestDto request);
        public Task<BaseResponse> DeleteBooking(int Id);
    }
}
