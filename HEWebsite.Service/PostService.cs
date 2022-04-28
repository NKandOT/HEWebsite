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

        public async Task AddReply(PostReply reply)
        {
            _context.PostReplies.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var post = GetById(Id);
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task EditPostContent(int Id, string newContent)
        {
            var post = GetById(Id);
            post.Content = newContent;
            _context.Update(post);
            await _context.SaveChangesAsync();
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

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            return string.IsNullOrEmpty(searchQuery)
                ? forum.Posts
                : forum.Posts
                    .Where(p => p.Title.Contains(searchQuery)
                    || p.Content.Contains(searchQuery));
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

        IEnumerable<Post> IPost.GetFilteredPosts(string searchQuery)
        {
            return GetAll().Where(p => p.Title.Contains(searchQuery)
                    || p.Content.Contains(searchQuery));
        }
    }
}
