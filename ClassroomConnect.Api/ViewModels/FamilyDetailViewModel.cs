using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class FamilyDetailViewModel
    {
        [Key]
        public Guid FamilyId { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<GuardianViewModel> Guardians { get; set; }
        public IEnumerable<ChildViewModel> Children { get; set; }
    }
}
