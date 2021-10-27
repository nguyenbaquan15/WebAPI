using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Model.Entity
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Department { get; set; }

    }
}
