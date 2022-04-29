using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using HEWebsite.Models.Forum;
using HEWebsite.Models.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        
        public ForumController(IForum forumService, IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel {
                    Id = forum.Id,
                    Title = forum.Title,
                    Description = forum.Description,
                    ForumImage = forum.ForumImage
                });
            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

        public IActionResult Topic(int Id, string searchQuery)
        {
            var forum = _forumService.GetById(Id);
            var posts = _postService.GetFilteredPosts(forum, searchQuery).ToList();

            var postListing = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                AuthorName = post.User.UserName,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });

            var model = new ForumTopicModel
            {
                Posts = postListing,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }

        public IActionResult Create()
        {
            var model = new AddForumModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddForum(AddForumModel model)
        {
            var filePathDb = @$"/Images/Forum/defaultForumImage.png";

            if (UploadFile(model.ImageUpload))
            {
                var fileName = Path.GetFileName(model.ImageUpload.FileName);
                var filePathUpload = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\forum", fileName);
                filePathDb = @$"/images/forum/{fileName}";
                using (var fileStream = new FileStream(filePathUpload, FileMode.Create))
                {
                    await model.ImageUpload.CopyToAsync(fileStream);
                }
            }

            var forum = new Forum 
            {
                Title = model.Title,
                Description = model.Description,
                Created = DateTime.UtcNow,
                ForumImage = filePathDb
            };

            await _forumService.Create(forum);

            return RedirectToAction("Index", "Forum");
        }

        private bool UploadFile(IFormFile ufile)
        {
            if (ufile != null && ufile.Length > 0)
            {
                return true;
            }
            return false;
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }


        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ForumImage = forum.ForumImage
            };
        }
    }
}
