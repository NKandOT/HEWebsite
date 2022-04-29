using HEWebsite.Data;
using HEWebsite.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Service
{
    public class TutorService : ITutor
    {
        private readonly ApplicationDbContext _context;

        public TutorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddTutor(string email, string name)
        {
            throw new NotImplementedException();
        }

        public Task AddTutor(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditTutorEmail(int id, string email)
        {
            throw new NotImplementedException();
        }

        public Task EditTutorName(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
