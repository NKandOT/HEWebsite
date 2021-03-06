using HEWebsite.Models.Reply;
using System;
using System.Collections.Generic;

namespace HEWebsite.Models.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public int AuthorRating { get; set; }
        public string Created { get; set; }
        public string PostContent { get; set; }
        
        public int ForumId { get; set; }
        public string ForumTitle { get; set; }
        
        public IEnumerable<PostReplyModel> Replies { get; set; }

        public bool IsAuthorAdmin { get; set; }
    }
}
