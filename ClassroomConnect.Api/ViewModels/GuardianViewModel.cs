using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class GuardianViewModel
    {
        [Key]
        public Guid GuardianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Email { get; set; }
        public bool IsPrimaryGuardian { get; set; }
        public Guid FamilyId { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? HomeAddressId { get; set; }
        public AddressViewModel HomeAddress { get; set; }
        public Guid? MobilePhoneId { get; set; }
        public PhoneViewModel MobilePhone { get; set; }
        public Guid? WorkAddressId { get; set; }
        public AddressViewModel WorkAddress { get; set; }
        public Guid? WorkPhoneId { get; set; }
        public PhoneViewModel WorkPhone { get; set; }

    }
}
