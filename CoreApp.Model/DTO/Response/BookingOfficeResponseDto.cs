using CoreApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Response
{
    public class BookingOfficeResponseDto:BaseResponse
    {
        public string Name { get; set; }
        public Trip Trip { get; set; }
        public string PhoneNumber { get; set; }
        //public string Price { get; set; }
        //public string Place { get; set; }
        //public DateTime Deadline { get; set; }
    }
}
