using HEWebsite.Data.Models;
using HEWebsite.Models.Reply;
using System;
using System.Collections.Generic;

namespace HEWebsite.Models.Course
{
    public class CourseIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Created { get; set; }
        public string Content { get; set; }
        public string Requirements { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }
        
        //public IEnumerable<Tutor> Tutors { get; set; }
    }
}
