using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public FamilyRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Family GetFamilyWithDetails(Guid familyId)
        {
            var family = FindByCondition(family => family.FamilyId.Equals(familyId))
                .Include(c => c.Children)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.HomeAddress)
                .Include(h => h.Guardians)
                    .ThenInclude(i => i.MobilePhone)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.WorkAddress)
                .Include(h => h.Guardians)
                    .ThenInclude(i => i.WorkPhone).FirstOrDefault();

            return family;
        }
    }
}
