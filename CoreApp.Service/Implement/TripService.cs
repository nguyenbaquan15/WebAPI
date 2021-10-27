using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Model.Respository;
using CoreApp.Model.UnitOfWork;
using CoreApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class TripService : ITripService
    {

        private readonly IGenericRespository<Trip> _tripRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TripService(IGenericRespository<Trip> tripRespository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tripRespository = tripRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse> CreateTrip(TripRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _trip = _mapper.Map<Trip>(request);

                await _tripRespository.Create(_trip).ConfigureAwait(false);
                _unitOfWork.Commit();
                _response.Result = "SUCCESS";
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;
        }


        public async Task<List<TripResponseDto>> GetAllTrip()
        {
            var _response = new List<TripResponseDto>();

            try
            {
                var _allTrip = _tripRespository.GetAll().ToList();

                _response = _mapper.Map<List<TripResponseDto>>(_allTrip);
            }
            catch (Exception)
            {

            }

            return _response;
        }

        public async Task<TripResponseDto> GetTripById(int Id)
        {
            var _response = new TripResponseDto();

            try
            {
                var _trip = _tripRespository.GetId().FirstOrDefault(b => b.TripId == Id);

                if (_trip != null)
                {
                    _response = _mapper.Map<TripResponseDto>(_trip);
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


        public async Task<BaseResponse> UpdateTrip(int Id, TripRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _trip = await _tripRespository.FindId(Id);

                var _item = _mapper.Map<Trip>(request);

                if (_trip != null)
                {
                    _trip.Destination = _item.Destination;
                    _trip.DepartureTime = _item.DepartureTime;
                    _trip.Driver = _item.Driver;
                    _trip.CarType = _item.CarType;
                    _trip.MaximumOnlineTicket = _item.MaximumOnlineTicket;
                    _trip.DepartureDate = _item.DepartureDate;

                    await _tripRespository.Update(_trip).ConfigureAwait(false);
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


        public async Task<BaseResponse> DeleteTrip(int Id)
        {
            var _response = new BaseResponse();

            try
            {
                var _trip = await _tripRespository.FindId(Id);

                if (_trip != null)
                {
                    await _tripRespository.Delete(_trip).ConfigureAwait(false);

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
