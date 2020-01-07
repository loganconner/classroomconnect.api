using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IGuardianRepository : IRepositoryBase<Guardian>
    {
        Guardian GetGuardianWithDetails(Guid guardianId);

        List<Guardian> GetChildGuardiansWithDetails(Guid familyId);
    }
}
