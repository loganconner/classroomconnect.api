using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ApprovedPickup { get; set; }
        public ContactType ContactType { get; set; }
        public DateTime EntryDate { get; set; }
        public string AddedBy { get; set; }
        public bool ApprovedByGuardians { get; set; }
        public Guid FamilyId { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public Guid? PhoneId { get; set; }
        [ForeignKey("PhoneId")]
        public Phone Phone { get; set; }
    }

    public enum ContactType
    {
        Emergency = 1,
        ApprovedRelease = 2,
        Both = 3
    }
}
