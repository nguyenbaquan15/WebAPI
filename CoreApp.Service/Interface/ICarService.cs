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
    public interface ICarService
    {
        public Task<BaseResponse> CreateCar(CarRequestDto request);
        public Task<List<CarResponseDto>> GetAllCar();
        public Task<CarResponseDto> GetCarById(int Id);
        public Task<BaseResponse> UpdateCar(int Id, CarRequestDto request);
        public Task<BaseResponse> DeleteCar(int Id);

    }
}
