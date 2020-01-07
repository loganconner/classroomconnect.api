using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class PersonAddressViewModel
    {
        public Guid PersonId { get; set; }
        public Guid AddressId { get; set; }
    }
}
