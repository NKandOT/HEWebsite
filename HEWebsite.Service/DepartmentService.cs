using HEWebsite.Data;
using HEWebsite.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HEWebsite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HEWebsite.Service
{
    public class DepartmentService : IDepartment
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Department department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int departmentId)
        {
            _context.Remove(departmentId);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.Include(d => d.Courses);
        }

        public Department GetById(int Id)
        {
            var department = _context.Departments.Where(d => d.Id == Id)
            .Include(d => d.Courses)
            .FirstOrDefault();

            return department;
        }

        public async Task UpdateDepartmentDescription(int departmentId, string newDescription)
        {
            var department = GetById(departmentId);
            department.Description = newDescription;
            _context.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentImage(int departmentId, string filePath)
        {
            var department = GetById(departmentId);
            department.DepartmentImage = filePath;
            _context.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentTitle(int departmentId, string newTitle)
        {
            var department = GetById(departmentId);
            department.Title = newTitle;
            _context.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
