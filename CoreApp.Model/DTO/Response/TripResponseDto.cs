using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Response
{
    public class TripResponseDto : BaseResponse
    {
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string Driver { get; set; }
        //public string CarType { get; set; }
        //public string MaximumOnlineTicket { get; set; }
        //public DateTime DepartureDate { get; set; }

    }
}
