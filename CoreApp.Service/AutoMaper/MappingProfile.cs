using AutoMapper;
using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.AutoMaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            /*------------------------ Mapper User ----------------------*/

            CreateMap<User, UserRequestDto>();
            CreateMap<UserRequestDto, User>();

            CreateMap<User, UserResponseDto>();
            CreateMap<UserResponseDto, User>();         

            /*--------------------------------------------------------------------*/


            /*------------------------ Mapper BookingOffice ----------------------*/

            CreateMap<BookingOffice, BookingOfficeRequestDto>();
            CreateMap<BookingOfficeRequestDto, BookingOffice>();

            CreateMap<BookingOffice, BookingOfficeResponseDto>();
            CreateMap<BookingOfficeResponseDto, BookingOffice>();

            /*--------------------------------------------------------------------*/

            /*---------------------------- Mapper Car ----------------------------*/

            CreateMap<Car, CarRequestDto>();
            CreateMap<CarRequestDto, Car>();

            CreateMap<Car, CarResponseDto>();
            CreateMap<CarResponseDto, Car>();

            /*---------------------------------------------------------------------*/


            /*---------------------------- Mapper Employee ------------------------*/

            CreateMap<Employee, EmployeeRequestDto>();
            CreateMap<EmployeeRequestDto, Employee>();

            CreateMap<Employee, EmployeeResponseDto>();
            CreateMap<EmployeeResponseDto, Employee>();

            /*----------------------------------------------------------------------*/


            /*---------------------------- Mapper Packing Lot ----------------------*/

            CreateMap<PackingLot, PackingLotRequestDto>();
            CreateMap<PackingLotRequestDto, PackingLot>();

            CreateMap<PackingLot, PackingLotResponseDto>();
            CreateMap<PackingLotResponseDto, PackingLot>();

            /*----------------------------------------------------------------------*/


            /*---------------------------- Mapper Ticket---------------------------*/

            CreateMap<Ticket, TicketRequestDto>();
            CreateMap<TicketRequestDto, Ticket>();

            CreateMap<Ticket, TicketResponseDto>();
            CreateMap<TicketResponseDto, Ticket>();

            /*----------------------------------------------------------------------*/


            /*---------------------------- Mapper Trip------------------------------*/
            CreateMap<Trip, TripRequestDto>();
            CreateMap<TripRequestDto, Trip>();


            CreateMap<Trip, TripResponseDto>();
            CreateMap<TripResponseDto, Trip>();

            /*----------------------------------------------------------------------*/

        }

    }
}
