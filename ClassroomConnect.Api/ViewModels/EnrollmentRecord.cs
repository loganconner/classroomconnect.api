
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class EnrollmentRecord
    {
        public ChildViewModel Child { get; set; } = new ChildViewModel();
        //public ClassroomViewModel Classroom { get; set; }
        public GuardianViewModel PrimaryGuardian { get; set; } = new GuardianViewModel();
        public GuardianViewModel SecondaryGuardian { get; set; } = new GuardianViewModel();
        public List<ContactViewModel> ContactList { get; set; } = new List<ContactViewModel>();

        public EnrollmentRecord()
        {
            Child = new ChildViewModel();
            PrimaryGuardian = new GuardianViewModel();
            SecondaryGuardian = new GuardianViewModel();
            //Classroom = new ClassroomViewModel();
            ContactList = new List<ContactViewModel>();
        }
    }
}
