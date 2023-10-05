using Lesson11.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lesson11.Services
{
    internal class SubjectsDbService
    {
        private readonly UniversityDbContext _context;

        public SubjectsDbService()
        {
            _context = new UniversityDbContext();
        }

        public List<Subject> GetSubjects() => _context.Subjects.ToList();
    }
}
