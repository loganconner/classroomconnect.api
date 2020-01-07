using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.ViewModels
{
    public class ClassroomViewModel
    {
        public Guid ClassroomId { get; set; }
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateTime ClassDate { get; set; }
        [ForeignKey("ClassroomId")]
        public List<StudentViewModel> Students { get; set; }

        public ClassroomViewModel() 
        {
            Students = new List<StudentViewModel>();    
        }
    }
}
