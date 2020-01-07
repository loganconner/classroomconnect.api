using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IClassroomRepository : IRepositoryBase<Classroom>
    {
        Classroom GetClassroomWithDetails(Guid classroomId);
    }
}
