using HEWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data.Interface
{
    public interface ITutor
    {
        public Task AddTutor(Tutor tutor);
        public Task EditTutorName(int id, string name);
        public Task EditTutorEmail(int id, string email);
        public Task DeleteTutor(int id);
        public Tutor GetById(int Id);
    }
}
