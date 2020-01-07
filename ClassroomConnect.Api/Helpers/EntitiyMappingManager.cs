using ClassroomConnect.Api.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.Helpers
{
    public class EntitiyMappingManager
    {
        public static Address MapAddressToBO(AddressViewModel vm)
        {
            Address addressBO = new Address()
            {
                AddressId = vm.AddressId,
                AddressLine1 = vm.AddressLine1,
                AddressLine2 = vm.AddressLine2,
                City = vm.City,
                State = vm.State,
                PostalCode = vm.PostalCode,
                AddressType = (Entities.Models.AddressType)vm.AddressType,
                IsValidAddress = vm.IsValidAddress,
                IsDeleted = vm.IsDeleted
            };            

            return addressBO;
        }

        public static Phone MapPhoneToBO(PhoneViewModel vm)
        {
            Phone phoneBO = new Phone()
            {
                PhoneId = vm.PhoneId,
                PhoneNumber = vm.PhoneNumber,
                PhoneType = (Entities.Models.PhoneType)vm.PhoneType,
                IsDeleted = vm.IsDeleted
            };

            return phoneBO;
        }

        public static Child MapChildToBO(ChildViewModel vm)
        {
            Child childBO = new Child()
            {
                ChildId = vm.ChildId,
                FamilyId = vm.FamilyId,
                FirstName = vm.FirstName,
                MiddleName = vm.MiddleName,
                LastName = vm.LastName,
                DOB = vm.DOB,
                EntryDate = vm.EntryDate,
                ClassroomId = vm.ClassroomId,
                IsDeleted = vm.IsDeleted,
                ImageUrl = vm.ImageUrl
            };

            return childBO;
        }

        public static Contact MapContactToBO(ContactViewModel vm)
        {
            Contact contactBO = new Contact()
            {
                ContactId = vm.ContactId,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                ApprovedByGuardians = vm.ApprovedByGuardians,
                ApprovedPickup = vm.ApprovedPickup,
                ContactType = (Entities.Models.ContactType)vm.ContactType,
                EntryDate = vm.EntryDate == null ? DateTime.Now : vm.EntryDate,
                FamilyId = vm.FamilyId,
                IsDeleted = vm.IsDeleted
            };

            return contactBO;
        }

        public static Guardian MapGuardianToBO(GuardianViewModel guardianVM)
        {
            Guardian guardianBO = new Guardian()
            {
                GuardianId = guardianVM.GuardianId,
                FirstName = guardianVM.FirstName,
                LastName = guardianVM.LastName,
                DOB = guardianVM.DOB,
                Email = guardianVM.Email,
                IsPrimaryGuardian = guardianVM.IsPrimaryGuardian,
                FamilyId = guardianVM.FamilyId,
                IsDeleted = guardianVM.IsDeleted
            };

            return guardianBO;
        }
    }
}
