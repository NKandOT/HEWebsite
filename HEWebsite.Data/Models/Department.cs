using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DepartmentImage { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
