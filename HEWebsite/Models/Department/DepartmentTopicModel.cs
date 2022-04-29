using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HEWebsite.Models.Course;

namespace HEWebsite.Models.Department
{
    public class DepartmentTopicModel
    {
        public DepartmentListingModel Department { get; set; }
        public IEnumerable<CourseListingModel> Courses { get; set; }
    }
}
