using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
    {
        public PhoneRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
