using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class AllergyViewModel
    {
        [Key]
        public int AllergyId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
