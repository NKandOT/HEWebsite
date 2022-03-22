using HEWebsite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HEWebsite.Data.Interface
{
    public interface IForum
    {
        Forum GetById(int Id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();
        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
    }
}
