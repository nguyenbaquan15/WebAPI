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
    public class CarService : ICarService
    {
        private readonly IGenericRespository<Car> _carRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(IGenericRespository<Car> carRespository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _carRespository = carRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse> CreateCar(CarRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _car = _mapper.Map<Car>(request);

                await _carRespository.Create(_car).ConfigureAwait(false);
                _unitOfWork.Commit();
                _response.Result = "SUCCESS";
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;

        }


        public async Task<List<CarResponseDto>> GetAllCar()
        {
            var _response = new List<CarResponseDto>();

            try
            {
                var _allCar = _carRespository.GetAll().Include(b => b.PackingLot).Include(b => b.Tickets).ToList();
                _response = _mapper.Map<List<CarResponseDto>>(_allCar);
            }
            catch (Exception)
            {

            }

            return _response;
        }


        public async Task<CarResponseDto> GetCarById(int Id)
        {

            var _response = new CarResponseDto();
            try
            {
                var _car = _carRespository.GetId().Include(b => b.PackingLot).FirstOrDefault(b => b.CarId == Id);

                if (_car != null)
                {
                    _response = _mapper.Map<CarResponseDto>(_car);
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


        public async Task<BaseResponse> UpdateCar(int Id, CarRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _car = await _carRespository.FindId(Id);
                var _item = _mapper.Map<Car>(request);

                if (_car != null)
                {
                    _car.LicensePlate = _item.LicensePlate;
                    _car.CarType = _item.CarType;
                    _car.CarColor = _item.CarColor;
                    _car.Company = _item.Company;

                    await _carRespository.Update(_car).ConfigureAwait(false);

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


        public async Task<BaseResponse> DeleteCar(int Id)
        {
            var _response = new BaseResponse();

            try
            {
                var _car = await _carRespository.FindId(Id);

                if (_car != null)
                {
                    await _carRespository.Delete(_car).ConfigureAwait(false);

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
