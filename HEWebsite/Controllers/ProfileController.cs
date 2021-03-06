using HEWebsite.Data.Models;
using HEWebsite.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HEWebsite.Models.ApplicationUser;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HEWebsite.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        public ProfileController(UserManager<ApplicationUser> userManager,
            IApplicationUser userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IActionResult> DetailAsync(string id) {
            
            var user = _userService.GetById(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new ProfileModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating,
                DisplayName = user.DisplayName,
                Email = user.Email,
                ProfileImage = user.UserImage,
                MemberSince = user.MemberSince,
                IsAdmin = userRoles.Contains("Admin")
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage (IFormFile file)
        {
            var userId = _userManager.GetUserId(User);
            if (UploadFile(file))
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePathUpload = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\profiles", fileName);
                var filePathDb = @$"/images/profiles/{fileName}";
                using (var fileStream = new FileStream(filePathUpload, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                await _userService.SetProfileImage(userId, filePathDb);
            }
            return RedirectToAction("Detail", "Profile", new { id = userId });
        }

        public IActionResult Index()
        {
            var profiles = _userService.GetAll()
                .OrderByDescending(u => u.Rating)
                .Select(u => new ProfileModel
                {
                    Email = u.Email,
                    DisplayName = u.DisplayName,
                    ProfileImage = u.UserImage,
                    UserRating = u.Rating,
                    MemberSince = u.MemberSince
                });

            var model = new ProfileListModel
            {
                Profiles = profiles
            };

            return View(model);
        }

        private bool UploadFile(IFormFile ufile)
        {
            if (ufile != null && ufile.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
