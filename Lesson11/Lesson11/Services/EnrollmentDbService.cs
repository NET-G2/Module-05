using Lesson11.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson11.Services
{
    internal class EnrollmentDbService
    {
        private readonly UniversityDbContext _context;

        public EnrollmentDbService()
        {
            _context = new UniversityDbContext();
        }

        public List<Enrollment> GetEnrollments()
        {
            return _context.Enrollments
                .Include("Student")
                .Include("Subject")
                .ToList();
        }

        public List<Enrollment> GetActiveEnrollments()
        {
            return _context.Enrollments
                .Include("Student")
                .Include("Subject")
                .Where(x => x.EndDate > DateTime.Now)
                .ToList();
        }

        public Enrollment CreateEnrollment(Enrollment enrollment)
        {
            var createdEnrollment = _context.Enrollments.Add(enrollment);

            _context.SaveChanges();

            return createdEnrollment;
        }
    }
}
