using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PersonPhone
    {
        public Guid PersonId { get; set; }
        [Key]
        public Guid PhoneId { get; set; }

        [ForeignKey("PhoneId")]
        public ICollection<Phone> Phones { get; set; }
    }
}
