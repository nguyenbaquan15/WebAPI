using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Response
{
    public class TicketResponseDto : BaseResponse
    {
        public string Customer { get; set; }
        public string BookingTime { get; set; }
        public string LicensePlate { get; set; }
        //public int TripId { get; set; }


    }
}
