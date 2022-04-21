using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Models.Post
{
    public class NewPostModel
    {
        public int ForumId { get; set; }
        public string ForumTitle { get; set; }
        public string AuthorName { get; set; }
        public string ForumImage { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

    }
}
