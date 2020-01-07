using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        Contact GetContactWithDetails(Guid contactId);

        List<Contact> GetChildContactsWithDetails(Guid familyId);
    } 
}
