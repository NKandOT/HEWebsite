using HEWebsite.Data;
using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(
                u => u.Id == id);
        }

        public async Task UpdateUserRating(string userId, Type type)
        {
            var user = GetById(userId);
            var newRating = CalculateUserRating(type, user.Rating);
            user.Rating = newRating;
            await _context.SaveChangesAsync();
        }

        private int CalculateUserRating(Type type, int rating)
        {
            var inc = 0;

            if (type == typeof(Post))
            {
                inc = 1;
            }
            if (type == typeof(PostReply))
            {
                inc = 3;
            }

            return rating + inc;
        }

        public async Task SetProfileImage(string id, string filePath)
        {
            var user = GetById(id);
            user.UserImage = filePath;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
