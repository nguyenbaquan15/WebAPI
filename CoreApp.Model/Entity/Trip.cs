using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.Entity
{
    public class Trip
    {
        [Required]
        public int TripId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Destination { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Driver { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string CarType { get; set; }

        
        public string MaximumOnlineTicket { get; set; }

        
        public DateTime DepartureDate { get; set; }

    }
}
