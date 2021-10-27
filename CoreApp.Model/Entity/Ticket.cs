using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.Entity
{
    public class Ticket
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public string BookingTime { get; set; }

        [Required]
        [ForeignKey("Car")]
        public string LicensePlate { get; set; }

        public int TripId { get; set; }                  

        public Trip Trip { get; set; }                  //foreign key

        public Car Car { get; set; }

    }
}
