using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class GuardianRepository : RepositoryBase<Guardian>, IGuardianRepository
    {
        public GuardianRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Guardian GetGuardianWithDetails(Guid guardianId)
        {
            var guardian = FindByCondition(guardian => guardian.GuardianId.Equals(guardianId))
                .Include(i => i.HomeAddress)
                .Include(p => p.WorkAddress)
                .Include(i => i.MobilePhone)
                .Include(p => p.WorkPhone)
                .FirstOrDefault();

            return guardian;
        }

        public List<Guardian> GetChildGuardiansWithDetails(Guid familyId)
        {
            var guardians = FindByCondition(guardian => guardian.FamilyId.Equals(familyId))
                .Include(i => i.HomeAddress)
                .Include(p => p.WorkAddress)
                .Include(i => i.MobilePhone)
                .Include(p => p.WorkPhone)
                .ToList();

            return guardians;
        }
    }
}
