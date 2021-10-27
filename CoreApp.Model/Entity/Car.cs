using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.Entity
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        [Key]
        public string LicensePlate { get; set; }

        [Required]
        public string CarType { get; set; }

        [Required]
        public string CarColor { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public int PackingLotId { get; set; }

        public PackingLot PackingLot { get; set; }  //foreign key

        public List<Ticket> Tickets { get; set; }
    }
}
