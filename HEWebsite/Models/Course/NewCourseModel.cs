using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Models.Course
{
    public class NewCourseModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }
        public string DepartmentImage { get; set; }
        public string CourseContent { get; set; }
        public string EntryRequirements { get; set; }

    }
}
