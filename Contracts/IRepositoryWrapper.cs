using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAddressRepository Address { get; }
        IChildRepository Child { get; }
        IAllergyRepository Allergy { get; }
        IChildAllergyRepository ChildAllergy { get; }
        IClassroomRepository Classroom { get; }
        IContactRepository Contact { get; }
        IEmployeeRepository Employee { get; }
        IFamilyRepository Family { get; }
        IGuardianRepository Guardian { get; }
        IPersonAddressRepository PersonAddress { get; }
        IPersonPhoneRepository PersonPhone { get; }
        IPhoneRepository Phone { get; }
        void Save();
    }
}
