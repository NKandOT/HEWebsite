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

        public async Task Add(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var course = GetById(Id);
            _context.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task EditCourseContent(int Id, string newContent)
        {
            var course = GetById(Id);
            course.Content = newContent;
            _context.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task EditCourseEntryRequirements(int Id, string newEntryRequirements)
        {
            var course = GetById(Id);
            course.EntryRequirements = newEntryRequirements;
            _context.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task EditCourseTitle(int Id, string newTitle)
        {
            var course = GetById(Id);
            course.EntryRequirements = newTitle;
            _context.Update(course);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetById(int Id)
        {
            return _context.Courses.Where(c => c.Id == Id).FirstOrDefault();
        }
    }
}
