using HEWebsite.Models.Department;
using HEWebsite.Models.Forum;

namespace HEWebsite.Models.Course
{
    public class CourseListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  DatePosted { get; set; }

        public DepartmentListingModel Department { get; set; }

    }
}
