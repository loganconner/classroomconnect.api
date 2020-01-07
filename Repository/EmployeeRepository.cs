using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
