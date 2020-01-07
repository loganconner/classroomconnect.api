using System;
using Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ChildAllergyRepository: RepositoryBase<ChildAllergy>, IChildAllergyRepository
    {
        public ChildAllergyRepository(ClassroomContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
