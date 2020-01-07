using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PersonPhoneRepository : RepositoryBase<PersonPhone>, IPersonPhoneRepository
    {
        public PersonPhoneRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
