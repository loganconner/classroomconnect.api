using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
   public class ChildRepository : RepositoryBase<Child>, IChildRepository
    {
        public ChildRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Child GetChildWithDetails(Guid childId)
        {
            var child = FindByCondition(c => c.ChildId.Equals(childId))
                .FirstOrDefault();

            return child;
        }
    }
}
