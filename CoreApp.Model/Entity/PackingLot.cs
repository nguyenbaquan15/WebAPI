using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.Entity
{
    public class PackingLot
    {
        [Required]
        public int PackingLotId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Packinglot { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Place { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Area { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Status { get; set; }
    }
}
