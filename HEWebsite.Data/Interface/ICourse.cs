using HEWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data.Interface
{
    public interface ICourse
    {
        public Course GetById(int Id);
        public IEnumerable<Course> GetAll();
        public IEnumerable<Course> GetFilteredCourses(Department department, string searchQuery);
        public IEnumerable<Course> GetFilteredCourses(string searchQuery);

        public Task Add(Course Course);
        public Task Delete(int Id);
        public Task EditCourseTitle(int Id, string newTitle);
        public Task EditCourseContent(int Id, string newContent);
        public Task EditCourseEntryRequirements(int Id, string newEntryRequirements);
    }
}
