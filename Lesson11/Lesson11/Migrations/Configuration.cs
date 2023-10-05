namespace Lesson11.Migrations
{
    using Bogus;
    using Lesson11.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lesson11.Models.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lesson11.Models.UniversityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (context.Students.Any())
            {
                return;
            }

            var faker = new Faker();

            List<Student> students = new List<Student>();
            List<Subject> subjects = new List<Subject>();
            List<Enrollment> enrollments = new List<Enrollment>();

            for (int i = 0; i < 100; i++)
            {
                students.Add(new Student()
                {
                    FullName = faker.Name.FullName(),
                    Age = DateTime.Now.Year - faker.Person.DateOfBirth.Year,
                    Email = faker.Person.Email,
                    PhoneNumber = faker.Person.Phone,
                });
            }

            for (int i = 0; i < 20; i++)
            {
                subjects.Add(new Subject()
                {
                    Name = faker.Name.JobTitle(),
                    NumberOfHours = faker.Random.Int(30, 180),
                    Price = faker.Random.Decimal(500, 5000)
                });
            }

            for (int i = 0; i < 150; i++)
            {
                var studentIndex = faker.Random.Int(0, students.Count - 1);
                var subjectIndex = faker.Random.Int(0, subjects.Count - 1);
                var student = students[studentIndex];
                var subject = subjects[subjectIndex];

                var enrollment = enrollments.FirstOrDefault(x => x.Student == student &&
                x.Subject == subject);

                if (enrollment != null)
                {
                    continue;
                }

                enrollments.Add(new Enrollment()
                {
                    Student = student,
                    Subject = subject,
                    StartDate = faker.Date.Past(),
                    EndDate = faker.Date.Future(),
                });
            }

            context.Students.AddOrUpdate(students.ToArray());
            context.Subjects.AddOrUpdate(subjects.ToArray());
            context.Enrollments.AddOrUpdate(enrollments.ToArray());
            context.SaveChanges();
        }
    }
}
