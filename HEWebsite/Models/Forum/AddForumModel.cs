using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEWebsite.Models.Forum
{
    public class AddForumModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
