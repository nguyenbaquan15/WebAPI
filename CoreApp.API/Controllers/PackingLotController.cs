using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using CoreApp.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PackingLotController : ControllerBase
    {
        private readonly IPackingLotService _packingLotService;

        public PackingLotController(IPackingLotService packingLotService)
        {
            _packingLotService = packingLotService;
        }


        [HttpPost("Add-Packing Lot")]
        public async Task<ActionResult<BaseResponse>> CreatePackingLot(PackingLotRequestDto packingLot)
        {
            var _response = await _packingLotService.CreatePackingLot(packingLot).ConfigureAwait(false);

            return Ok(_response);
        }

        [HttpGet("List-Packing Lot")]
        public async Task<ActionResult<PackingLotResponseDto>> GetAllPackingLot()
        {
            var _response = await _packingLotService.GetAllPackingLot().ConfigureAwait(false);

            return Ok(_response);
        }

        [HttpGet("Get-Packing Lot-ByID")]
        public async Task<ActionResult<PackingLotResponseDto>> GetPackingLotById(int Id)
        {
            var _response = await _packingLotService.GetPackingLotById(Id);

            return Ok(_response);
        }


        [HttpPut("Update-Packing Lot-ByID")]
        public async Task<ActionResult<BaseResponse>> UpdatePackingLot(int Id, PackingLotRequestDto packingLot)
        {
            var _response = await _packingLotService.UpdatePackingLot(Id, packingLot).ConfigureAwait(false);

            return Ok(_response);
        }


        [HttpDelete("Delete-Packing Lot-ByID")]
        public async Task<ActionResult<BaseResponse>> DeletePackingLot(int Id)
        {
            var _response = await _packingLotService.DeletePackingLot(Id).ConfigureAwait(false);

            return Ok(_response);
        }
    }
}
