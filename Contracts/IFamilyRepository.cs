using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IFamilyRepository : IRepositoryBase<Family>
    {
        Family GetFamilyWithDetails(Guid familyId);
    }
}
