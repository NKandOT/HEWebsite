﻿using System;
using System.Collections.Generic;

namespace HEWebsite.Data.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ForumImage { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }

    }
}
