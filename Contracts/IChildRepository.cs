using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IChildRepository : IRepositoryBase<Child>
    {
        Child GetChildWithDetails(Guid childId);
    }
}
