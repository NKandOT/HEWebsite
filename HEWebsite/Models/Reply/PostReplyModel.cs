namespace HEWebsite.Models.Reply
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public int AuthorId { get; set; }
        public string AutherImage { get; set; }
        public string DatePosted { get; set; }

        public string ReplyContent { get; set; }

        public int PostId { get; set; }
    }
}
