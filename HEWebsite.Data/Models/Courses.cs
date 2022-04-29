using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data.Models
{
    class Courses
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Created { get; set; }
        public virtual Departments Department { get; set; }
    }
}
