using HEWebsite.Data;
using HEWebsite.Data.Interface;
using HEWebsite.Data.Models;
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

        public async Task AddTutor(Tutor tutor)
        {
            _context.Add(tutor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTutor(int id)
        {
            var tutor = GetById(id);
            _context.Remove(tutor);
            await _context.SaveChangesAsync();
        }

        public async Task EditTutorEmail(int id, string email)
        {
            var tutor = GetById(id);
            tutor.Email = email;
            _context.Update(tutor);
            await _context.SaveChangesAsync();
        }

        public async Task EditTutorName(int id, string name)
        {
            var tutor = GetById(id);
            tutor.Name = name;
            _context.Update(tutor);
            await _context.SaveChangesAsync();
        }

        public Tutor GetById(int Id)
        {
            return _context.Tutors.Where(t => t.Id == Id).FirstOrDefault();
        }
    }
}
