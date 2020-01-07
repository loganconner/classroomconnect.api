using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Family
    {
        [Key]
        public Guid FamilyId { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("FamilyId")]
        public ICollection<Guardian> Guardians { get; set; }
        [ForeignKey("FamilyId")]
        public ICollection<Child> Children { get; set; }
    }
}
