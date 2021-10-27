using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Request
{
    public class PackingLotRequestDto
    {
        
        public string Packinglot { get; set; }
        public string Place { get; set; }
        public string Area { get; set; }
        public string Price { get; set; }
    }
}
