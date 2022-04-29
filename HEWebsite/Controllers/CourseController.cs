using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using HEWebsite.Models.Course;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Controllers
{    
    public class CourseController : Controller
    {
        private readonly ICourse _courseService;
        private readonly IDepartment _departmentService;

        public CourseController(ICourse courseService, IDepartment departmentService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
        }

        public IActionResult Index(int id)
        {
            var course = _courseService.GetById(id);

            var model = new CourseIndexModel
            {
                Id = course.Id,
                Title = course.Title,
                Created = course.Created,
                Content = course.Content,
                DepartmentId = course.Department.Id,
                DepartmentTitle = course.Department.Title,
                Tutors = course.Tutors
            };

            return View(model);
        }

        public IActionResult Create(int id)
        {
            var department = _departmentService.GetById(id);

            var model = new NewCourseModel
            {
                DepartmentId = department.Id,
                DepartmentTitle = department.Title,
                DepartmentImage = department.DepartmentImage
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(NewCourseModel model)
        {
            var course = BuildNewCourse(model);

            await _courseService.Add(course);

            return RedirectToAction("Index", "Course", new { id = course.Id });
        }

        private Course BuildNewCourse(NewCourseModel model)
        {
            var department = _departmentService.GetById(model.DepartmentId);

            return new Course
            {
                Title = model.CourseTitle,
                Content = model.CourseContent,
                Created = DateTime.Now.ToString(),
                Department = department
            };
        }
    }
}
