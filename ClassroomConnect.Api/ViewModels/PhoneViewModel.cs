using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class PhoneViewModel
    {
        [Key]
        public Guid PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
        public bool IsDeleted { get; set; }
    }

    public enum PhoneType
    {
        Mobile = 1,
        Work = 3
    }
}
