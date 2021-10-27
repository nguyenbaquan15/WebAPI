﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Request
{
    public class CarRequestDto
    {

        public int CarId { get; set; }
        public string LicensePlate { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }
        public string Company { get; set; }
        public int PackingLotId { get; set; }
    }
}
