using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HEWebsite.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {        
        public string DisplayName { get; set; }
        public int Rating { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActive { get; set; }
        public string UserImage { get; set; }
    }
}
