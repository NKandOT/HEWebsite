using HEWebsite.Data;
using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Service
{
    class CourseService :ICourse
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(Course Course)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task EditCourseContent(int Id, string newContent)
        {
            throw new NotImplementedException();
        }

        public Task EditCourseEntryRequirements(int Id, string newEntryRequirements)
        {
            throw new NotImplementedException();
        }

        public Task EditCourseTitle(int Id, string newTitle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public Course GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCourseByDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetFilteredCourse(Department Department, string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetFilteredCourse(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
