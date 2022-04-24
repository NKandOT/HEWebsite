using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using HEWebsite.Models.Forum;
using HEWebsite.Models.Post;
using HEWebsite.Models.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postservice;

        public SearchController(IPost postservice)
        {
            _postservice = postservice;
        }

        public IActionResult Results(string searchQuery)
        {
            var posts = _postservice.GetFilteredPosts(searchQuery).ToList();
            var areEmptyResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

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

            var Model = new SearchResultsModel
            {
                Posts = postListing,
                SearchQuery = searchQuery,
                EmptySearchResults = areEmptyResults
            };
            
            return View(Model);
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            
            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ForumImage = forum.ForumImage
            };
        }
    }
}
