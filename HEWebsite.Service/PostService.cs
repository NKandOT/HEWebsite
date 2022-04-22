using HEWebsite.Data;
using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int Id, string newContent)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Post> IPost.GetAll()
        {
            return _context.Posts
            .Include(post => post.User)
            .Include(post => post.Replies)
                .ThenInclude(replies => replies.User)
            .Include(post => post.Forum);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
            .Include(post => post.User)
            .Include(post => post.Replies)
                .ThenInclude(replies => replies.User)
            .Include(post => post.Forum)
            .First();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Post> IPost.GetPostsByForum(int id)
        {
            return _context.Forums.Where(forum => forum.Id == id).First().Posts;
        }

        IEnumerable<Post> IPost.GetLatestPosts(int nPosts)
        {
            return GetAll().OrderByDescending(Post => Post.Created).Take(nPosts);
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.Include(posts => posts.Forum);
        }
    }
}
