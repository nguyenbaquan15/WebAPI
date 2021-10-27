using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.Entity
{
    public class PackingLot
    {
        [Required]
        public int PackingLotId { get; set; }

        [Required]
        public string Packinglot { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Price { get; set; }

        
    }
}
