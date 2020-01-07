using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Child
    {
        private string _fullName = null;

        [Key]
        public Guid ChildId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_fullName) && !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName))
                    return string.IsNullOrEmpty(this.MiddleName) ? this.FirstName + " " + this.LastName : this.FirstName + " " + this.MiddleName + " " + this.LastName;
                else
                    return this._fullName?.Trim();
            }
            set
            {
                _fullName = value;
            }
        }
        public DateTime? DOB { get; set; }
        public Guid FamilyId { get; set; }
        public Guid ClassroomId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int IsDeleted { get; set; }
        public string ImageUrl { get; set; }

        public IDictionary<int,ChildAllergy> Allergies { get; set; }
    }
}
