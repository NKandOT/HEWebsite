using HEWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data.Interface
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        ApplicationUser GetByName(string name);
        IEnumerable<ApplicationUser> GetAll();
        
        Task SetProfileImage(string id, string filePath);
        Task IncramentRating(string id, Type type);


    }
}
