using System;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClassroomRepository : RepositoryBase<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Classroom GetClassroomWithDetails(Guid classroomId)
        {
            var classroom = FindByCondition(c => c.ClassroomId.Equals(classroomId)).Include(c => c.Students).FirstOrDefault();

            return classroom;
        }
    }
}
