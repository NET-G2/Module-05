using Lesson11.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson11.Services
{
    internal class StudentDbService
    {
        private readonly UniversityDbContext _context;

        public StudentDbService()
        {
            _context = new UniversityDbContext();
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public Student CreateStudent(Student student)
        {
            var createdStudent = _context.Students.Add(student);

            return createdStudent;
        }

        public Student UpdateStudent(Student student)
        {
            var studentToUpdate = _context.Students.FirstOrDefault(x => x.Id == student.Id);

            if (studentToUpdate == null)
            {
                throw new ArgumentException($"Student with id: {student.Id} does not exist");
            }

            studentToUpdate.FullName = student.FullName;
            studentToUpdate.Age = student.Age;
            studentToUpdate.PhoneNumber = student.PhoneNumber;
            studentToUpdate.Email = student.Email;

            _context.Entry(studentToUpdate).State = System.Data.Entity.EntityState.Modified;

            _context.SaveChanges();

            return studentToUpdate;
        }

        public void DeleteStudent(int id)
        {
            var studentToDelete = _context.Students.FirstOrDefault(x => x.Id == id);

            if (studentToDelete == null)
            {
                throw new ArgumentException($"Student with id: {id} does not exist");
            }

            _context.Students.Remove(studentToDelete);
            _context.SaveChanges();
        }
    }
}
