using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassroomConnect.Api.ViewModels
{
    [Table("Address")]
    public class AddressViewModel
    {
        [Key]
        public Guid AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public AddressType AddressType { get; set; }
        public int IsValidAddress { get; set; }
        public bool IsDeleted { get; set; }
    }

    public enum AddressType
    {
        Home = 1,
        Work = 2,
    }
}
