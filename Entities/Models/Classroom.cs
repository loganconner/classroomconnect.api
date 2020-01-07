using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Classroom
    {
        public Guid ClassroomId { get; set; }
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateTime ClassDate { get; set; }

        [ForeignKey("ClassroomId")]
        public IEnumerable<Child> Students { get; set; }
    }
}
