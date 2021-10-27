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
    public interface IPackingLotService
    {
        public Task<BaseResponse> CreatePackingLot(PackingLotRequestDto request);
        public Task<List<PackingLotResponseDto>> GetAllPackingLot();
        public Task<PackingLotResponseDto> GetPackingLotById(int Id);
        public Task<BaseResponse> UpdatePackingLot(int Id, PackingLotRequestDto request);
        public Task<BaseResponse> DeletePackingLot(int Id);
    }
}
