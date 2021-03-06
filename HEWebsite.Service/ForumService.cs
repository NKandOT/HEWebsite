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
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;
        
        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Forum forum)
        {
            _context.Add(forum);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int forumId)
        {
            _context.Remove(forumId);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            return _context.Users.Where(u => u.IsActive == true);
        }

        public Forum GetById(int Id)
        {
            var forum = _context.Forums.Where(f => f.Id == Id)
            .Include(f => f.Posts)
                .ThenInclude(p => p.User)
            .Include(f => f.Posts)
                .ThenInclude(p => p.Replies)
                    .ThenInclude(r => r.User)
            .FirstOrDefault();

            return forum;
        }

        public async Task UpdateForumDescription(int forumId, string newDescription)
        {
            var forum = GetById(forumId);
            forum.Description = newDescription;
            _context.Update(forum);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateForumTitle(int forumId, string newTitle)
        {
            var forum = GetById(forumId);
            forum.Title = newTitle;
            _context.Update(forum);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateForumImage(int forumId, string filePath)
        {
            var forum = GetById(forumId);
            forum.ForumImage = filePath;
            _context.Update(forum);
            await _context.SaveChangesAsync();
        }
    }
}
