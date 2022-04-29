using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using HEWebsite.Models.Course;
using HEWebsite.Models.Department;
using HEWebsite.Models.Forum;
using HEWebsite.Models.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _departmentService;
        private readonly ICourse _courseService;

        public DepartmentController(IDepartment departmentService, ICourse courseService)
        {
            _departmentService = departmentService;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAll()
                .Select(department => new DepartmentListingModel
                {
                    Id = department.Id,
                    Title = department.Title,
                    Description = department.Description,
                    DepartmentImage = department.DepartmentImage
                });
            var model = new DepartmentIndexModel
            {
                DepartmentList = departments
            };

            return View(model);
        }

        public IActionResult Topic(int Id, string searchQuery)
        {
            var department = _departmentService.GetById(Id);
            var courses = _courseService.GetFilteredCourses(department, searchQuery).ToList();

            var courseListing = courses.Select(course => new CourseListingModel
            {
                Id = course.Id,
                Title = course.Title,
                DatePosted = course.Created.ToString(),
                Department = BuildDepartmentListing(course)
            });

            var model = new DepartmentTopicModel
            {
                Courses = courseListing,
                Department = BuildDepartmentListing(department)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }

        public IActionResult Create()
        {
            var model = new AddDepartmentModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentModel model)
        {
            var filePathDb = @$"/Images/Department/defaultDepartmentImage.png";

            if (UploadFile(model.ImageUpload))
            {
                var fileName = Path.GetFileName(model.ImageUpload.FileName);
                var filePathUpload = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images\Department", fileName);
                filePathDb = @$"/Images/Department/{fileName}";
                using (var fileStream = new FileStream(filePathUpload, FileMode.Create))
                {
                    await model.ImageUpload.CopyToAsync(fileStream);
                }
            }

            var department = new Department
            {
                Title = model.Title,
                Description = model.Description,
                Created = DateTime.UtcNow,
                DepartmentImage = filePathDb
            };

            await _departmentService.Create(department);

            return RedirectToAction("Index", "Forum");
        }

        private bool UploadFile(IFormFile ufile)
        {
            if (ufile != null && ufile.Length > 0)
            {
                return true;
            }
            return false;
        }

        private DepartmentListingModel BuildDepartmentListing(Course course)
        {
            var department = course.Department;
            return BuildDepartmentListing(department);
        }


        private DepartmentListingModel BuildDepartmentListing(Department department)
        {
            return new DepartmentListingModel
            {
                Id = department.Id,
                Title = department.Title,
                DepartmentImage = department.DepartmentImage
            };
        }
    }
}
