using HEWebsite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HEWebsite.Data.Interface
{
    public interface IPost
    {
        public Post GetById(int Id);
        public IEnumerable<Post> GetAll();
        public IEnumerable<Post> GetFilteredPosts(string searchQuery);
        public IEnumerable<Post> GetPostsByForum(int id);
        public IEnumerable<Post> GetLatestPosts(int nPosts);

        public Task Add(Post post);
        public Task Delete(int Id);
        public Task EditPostContent(int Id, string newContent);
        public Task AddReply(PostReply reply);
    }
}
