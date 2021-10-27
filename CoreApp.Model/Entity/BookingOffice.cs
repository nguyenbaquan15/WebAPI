using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.Entity
{
    public class BookingOffice
    {
        [Required]
        public int BookingOfficeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TripId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        
        public Trip Trip { get; set; }      //foreign key


    }

}
