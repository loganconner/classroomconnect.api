using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Guardian
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
        [ForeignKey("HomeAddressId")]
        public Address HomeAddress { get; set; }
        public Guid? MobilePhoneId { get; set; }
        [ForeignKey("MobilePhoneId")]
        public Phone MobilePhone { get; set; }
        public Guid? WorkAddressId { get; set; }
        [ForeignKey("WorkAddressId")]
        public Address WorkAddress { get; set; }
        public Guid? WorkPhoneId { get; set; }
        [ForeignKey("WorkPhoneId")]
        public Phone WorkPhone { get; set; }
               
    }
}
