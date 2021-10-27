using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.DTO.Response
{
    public class EmployeeResponseDto:BaseResponse
    {
        public string Fullname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Sex { get; set; }

        //public string Address { get; set; }

        //public string PhoneNumber { get; set; }

        //public string Email { get; set; }

        //public string Account { get; set; }

        //public string Password { get; set; }

        //public string Department { get; set; }
    }
}
