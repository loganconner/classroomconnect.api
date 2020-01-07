using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PersonAddress
    {
        
        public Guid PersonAddressId { get; set; }
        public Guid PersonId { get; set; }
        [Key]
        public Guid AddressId { get; set; }

        [ForeignKey("AddressId")]
        public ICollection<Address> Addresses { get; set; }
    }
}
