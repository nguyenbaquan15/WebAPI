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
    public class PackingLotService : IPackingLotService
    {
        private readonly IGenericRespository<PackingLot> _packingLotRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PackingLotService(IGenericRespository<PackingLot> packingLotRespository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _packingLotRespository = packingLotRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse> CreatePackingLot(PackingLotRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _packingLot = _mapper.Map<PackingLot>(request);

                await _packingLotRespository.Create(_packingLot).ConfigureAwait(false);
                _unitOfWork.Commit();
                _response.Result = "SUCCESS";
            }
            catch (Exception)
            {
                _response.Result = "ERROR";
            }

            return _response;

        }


        public async Task<List<PackingLotResponseDto>> GetAllPackingLot()
        {
            var _response = new List<PackingLotResponseDto>();

            try
            {
                var _allPackingLot = _packingLotRespository.GetAll().ToList();

                _response = _mapper.Map<List<PackingLotResponseDto>>(_allPackingLot);
            }
            catch (Exception)
            {

            }

            return _response;
        }


        public async Task<PackingLotResponseDto> GetPackingLotById(int Id)
        {
            var _response = new PackingLotResponseDto();

            try
            {
                var _packingLot = _packingLotRespository.GetId().FirstOrDefault(b => b.PackingLotId == Id);

                if (_packingLot != null)
                {
                    _response = _mapper.Map<PackingLotResponseDto>(_packingLot);
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


        public async Task<BaseResponse> UpdatePackingLot(int Id, PackingLotRequestDto request)
        {
            var _response = new BaseResponse();

            try
            {
                var _packingLot = await _packingLotRespository.FindId(Id);

                var _item = _mapper.Map<PackingLot>(request);

                if (_packingLot != null)
                {
                    _packingLot.Packinglot = _item.Packinglot;
                    _packingLot.Place = _item.Place;
                    _packingLot.Area = _item.Area;
                    _packingLot.Price = _item.Price;

                    await _packingLotRespository.Update(_packingLot).ConfigureAwait(false);
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


        public async Task<BaseResponse> DeletePackingLot(int Id)
        {
            var _response = new BaseResponse();

            try
            {
                var _packingLot = await _packingLotRespository.FindId(Id);

                if (_packingLot != null)
                {
                    await _packingLotRespository.Delete(_packingLot).ConfigureAwait(false);

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
