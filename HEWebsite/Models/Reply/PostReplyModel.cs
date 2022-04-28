namespace HEWebsite.Models.Reply
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string AuthorImage { get; set; }
        public bool IsAuthorAdmin { get; set; }        
        public string ReplyCreated { get; set; }
        public string ReplyContent { get; set; }

        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        public int ForumId { get; set; }
        public string ForumTitle { get; set; }
        public string ForumImage { get; set; }

    }
}
