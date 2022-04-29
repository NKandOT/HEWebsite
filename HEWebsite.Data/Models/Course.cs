using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string EntryRequirements { get; set; }
        public string Created { get; set; }
        public virtual Department Department { get; set; }
        public IEnumerable<Tutor> Tutors { get; set; }
    }
}
