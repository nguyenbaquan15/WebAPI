using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "varchar(20)")]
        public string LicensePlate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CarType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string CarColor { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Company { get; set; }

        [Required]
        public int PackingLotId { get; set; }

        public PackingLot PackingLot { get; set; }  //foreign key

        public List<Ticket> Tickets { get; set; }
    }
}
