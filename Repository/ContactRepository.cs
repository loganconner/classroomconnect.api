using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Contact GetContactWithDetails(Guid contactId)
        {
            var contact = FindByCondition(contact => contact.ContactId.Equals(contactId))
                .Include(a => a.Address)
                .Include(t => t.Phone)
                .FirstOrDefault();

            return contact;
        }

        public List<Contact> GetChildContactsWithDetails(Guid familyId)
        {
            var contacts = FindByCondition(contact => contact.FamilyId.Equals(familyId))
                .Include(a => a.Address)
                .Include(t => t.Phone)
                .ToList();

            return contacts;
        }
    }
}
