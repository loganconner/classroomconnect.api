using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PersonAddressRepository : RepositoryBase<PersonAddress>, IPersonAddressRepository
    {
        public PersonAddressRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
