using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class StudentViewModel
    {
        public Guid ChildId { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Guid PrimaryGuardianId { get; set; }
        public string PrimaryGuardianName { get; set; }
        public Guid SecondaryGuardianId { get; set; }
        public string SecondaryGuardianName { get; set; }
        public Guid FamilyId { get; set; }
    }
}
