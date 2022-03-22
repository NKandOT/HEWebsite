using HEWebsite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HEWebsite.Data.Interface
{
    public interface IPost
    {
        IPost GetById(int Id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);

        Task Add(Post post);
        Task Delete(int Id);
        Task EditPostContent(int Id, string newContent);
        Task AddReply(PostReply reply);
        
    }
}
