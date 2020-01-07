using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ClassroomContext _repoContext;
        private IAddressRepository _address;
        private IChildRepository _child;
        private IAllergyRepository _allergy;
        private IChildAllergyRepository _childAllergy;
        private IClassroomRepository _classroom;
        private IContactRepository _contact;
        private IEmployeeRepository _employee;
        private IFamilyRepository _family;
        private IGuardianRepository _guardian;
        private IPersonAddressRepository _personAddress;
        private IPersonPhoneRepository _personPhone;
        private IPhoneRepository _phone;

        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_repoContext);
                }

                return _address;
            }
        }

        public IChildRepository Child
        {
            get
            {
                if (_child == null)
                {
                    _child = new ChildRepository(_repoContext);
                }

                return _child;
            }
        }
        public IAllergyRepository Allergy
        {
            get
            {
                if (_allergy == null)
                {
                    _allergy = new AllergyRepository(_repoContext);
                }

                return _allergy;
            }
        }
        public IChildAllergyRepository ChildAllergy
        {
            get
            {
                if (_childAllergy == null)
                {
                    _childAllergy = new ChildAllergyRepository(_repoContext);
                }

                return _childAllergy;
            }
        }
        public IClassroomRepository Classroom
        {
            get
            {
                if (_classroom == null)
                {
                    _classroom = new ClassroomRepository(_repoContext);
                }

                return _classroom;
            }
        }
        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_repoContext);
                }

                return _contact;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }

                return _employee;
            }
        }
        public IFamilyRepository Family
        {
            get
            {
                if (_family == null)
                {
                    _family = new FamilyRepository(_repoContext);
                }

                return _family;
            }
        }
        public IGuardianRepository Guardian
        {
            get
            {
                if (_guardian == null)
                {
                    _guardian = new GuardianRepository(_repoContext);
                }

                return _guardian;
            }
        }
        public IPersonAddressRepository PersonAddress
        {
            get
            {
                if (_personAddress == null)
                {
                    _personAddress = new PersonAddressRepository(_repoContext);
                }

                return _personAddress;
            }
        }
        public IPersonPhoneRepository PersonPhone
        {
            get
            {
                if (_personPhone == null)
                {
                    _personPhone = new PersonPhoneRepository(_repoContext);
                }

                return _personPhone;
            }
        }
        public IPhoneRepository Phone
        {
            get
            {
                if (_phone == null)
                {
                    _phone = new PhoneRepository(_repoContext);
                }

                return _phone;
            }
        }

        public RepositoryWrapper(ClassroomContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
