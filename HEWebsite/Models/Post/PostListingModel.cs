﻿using HEWebsite.Models.Forum;

namespace HEWebsite.Models.Post
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public int AuthorId { get; set; }
        public string AutherImage { get; set; }
        public string  DatePosted { get; set; }

        public ForumListingModel Forum { get; set; }

        public int RepliesCount { get; set; }

    }
}
