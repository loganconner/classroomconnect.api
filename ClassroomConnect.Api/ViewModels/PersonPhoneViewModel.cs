using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class PersonPhoneViewModel
    {
        [Key]
        public Guid PersonId { get; set; }
        [Key]
        public Guid PhoneId { get; set; }
    }
}
