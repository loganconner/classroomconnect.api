using Entities.Models;
using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
