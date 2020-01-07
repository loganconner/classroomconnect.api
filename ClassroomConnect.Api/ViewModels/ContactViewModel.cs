using ClassroomConnect.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class ContactViewModel
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
        public AddressViewModel Address { get; set; }
        public Guid? PhoneId { get; set; }
        public PhoneViewModel Phone { get; set; }
    }

    public enum ContactType
    {
        Emergency = 1,
        ApprovedRelease = 2,
        Both = 3
    }
}
