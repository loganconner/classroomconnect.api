using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DOB { get; set; }
        public int SSN { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

    }
}
