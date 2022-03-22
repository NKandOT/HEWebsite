using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
using HEWebsite.Models.Post;
using HEWebsite.Models.Reply;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HEWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        
        public PostController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var replies = BuildPostReplies(post.);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.Username,
                AuthorImage = post.User.UserImage,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies

            };

            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId=reply.User.Id,
                AutherImage = reply.User.UserImage,
                AuthorRating=reply.User.Rating,
                DatePosted = reply.DatePosted,
                ReplyContent = reply.Content
            });
        }
    }
}
