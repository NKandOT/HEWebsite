using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using HEWebsite.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;

        public ReplyController(IPost postService, UserManager<ApplicationUser> userManager, IApplicationUser userService)
        {
            _postService = postService;
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IActionResult> CreateAsync(int id)
        {
            var post = _postService.GetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new PostReplyModel
            {
                AuthorName = user.DisplayName,
                AuthorRating = user.Rating,
                AuthorId = user.Id,
                AuthorImage = user.UserImage,
                IsAuthorAdmin = IsAuthorAdmin(user),
                ReplyCreated = DateTime.UtcNow.ToString(),

                PostId = post.Id,
                PostTitle = post.Title,
                PostContent = post.Content,

                ForumId = post.Forum.Id,
                ForumTitle = post.Forum.Title,
                ForumImage = post.Forum.ForumImage
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user);

            await _postService.AddReply(reply); await _userService.UpdateUserRating(userId, typeof(PostReply));


            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }

        private PostReply BuildReply(PostReplyModel model, ApplicationUser user)
        {
            var post = _postService.GetById(model.PostId);

            return new PostReply 
            { 
                Post = post,
                Content = model.ReplyContent,
                Created = model.ReplyCreated,
                User = user
            };
        }

        private bool IsAuthorAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user)
                .Result.Contains("Admin");
        }
    }
}
