using HEWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data.Interface
{
    public interface IDepartment
    {
        Department GetById(int Id);
        IEnumerable<Department> GetAll();
        Task Create(Department Department);
        Task Delete(int DepartmentId);
        Task UpdateDepartmentTitle(int DepartmentId, string newTitle);
        Task UpdateDepartmentDescription(int DepartmentId, string newDescription);
        Task UpdateDepartmentImage(int DepartmentId, string filePath);
    }
}
