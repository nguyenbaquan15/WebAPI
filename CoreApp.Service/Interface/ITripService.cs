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
    public interface ITripService
    {
        public Task<BaseResponse> CreateTrip(TripRequestDto request);
        public Task<BaseResponse> DeleteTrip(int Id);
        public Task<List<TripResponseDto>> GetAllTrip();
        public Task<TripResponseDto> GetTripById(int Id);
        public Task<BaseResponse> UpdateTrip(int Id, TripRequestDto request);
    }
}
